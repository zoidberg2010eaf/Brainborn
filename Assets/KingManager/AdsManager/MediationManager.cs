using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Mediation;
using System;

public class MediationManager : MonoBehaviour
{
    public delegate void MediationAdsDelegate(bool isReward);

    IInterstitialAd interstitialAd;
    IRewardedAd rewardedAd;


    MediationAdsDelegate adsCallback;

    public KingSettings kingSettings;

    
    string CurrentInterstetialId;
    string CurrentRewardedId;
    string CurrentBannerId;
    //ShowOptions options = new ShowOptions();

    bool isInitialized = false;

    public bool adStarted, adCompleted;
    public string myAdStatus;
    

     GameObject _panelObject;

    string adUnitId, adUnitIdRewarded;

    public static MediationManager sharedInstance;

    public static  MediationManager SharedInstance
    {
        get
        {
            if (!sharedInstance)
            {   
                GameObject obj = new GameObject("MediationManager");

                sharedInstance = obj.AddComponent<MediationManager>();
                sharedInstance.kingSettings = Resources.Load<KingSettings>("KingSettings");
                DontDestroyOnLoad(sharedInstance);
                Debug.Log(sharedInstance.kingSettings.Unity_Android_GameId);


                return sharedInstance;
            }
             return sharedInstance;
            
        }
    }

    public async void Init(){
        if(!isInitialized){
#if UNITY_ANDROID
            InitializationOptions options = new InitializationOptions();
            options.SetGameId(sharedInstance.kingSettings.Unity_Android_GameId);

            await UnityServices.InitializeAsync(options);

            sharedInstance.CurrentInterstetialId = sharedInstance.kingSettings.Unity_Android_Interstitial_AdUnitId;
            sharedInstance.CurrentRewardedId = sharedInstance.kingSettings.Unity_Android_Rewarded_AdUnitId;
            sharedInstance.CurrentBannerId = sharedInstance.kingSettings.Unity_Android_Banner_AdUnitId;
            
#else

            InitializationOptions options = new InitializationOptions();
            options.SetGameId(sharedInstance.kingSettings.Unity_iOS_GameId);
            
            await UnityServices.InitializeAsync(options);

            sharedInstance.CurrentInterstetialId = sharedInstance.kingSettings.Unity_IOS_Interstitial_AdUnitId;
            sharedInstance.CurrentRewardedId = sharedInstance.kingSettings.Unity_IOS_Rewarded_AdUnitId;
            sharedInstance.CurrentBannerId = sharedInstance.kingSettings.Unity_IOS_Banner_AdUnitId;

#endif
            sharedInstance.interstitialAd = MediationService.Instance.CreateInterstitialAd(sharedInstance.CurrentInterstetialId);
            sharedInstance.interstitialAd.OnLoaded += AdLoaded;
            sharedInstance.interstitialAd.OnFailedLoad += AdFailedToLoad;
            sharedInstance.interstitialAd.OnShowed += AdShown;
            sharedInstance.interstitialAd.OnFailedShow += AdFailedToShow;
            sharedInstance.interstitialAd.OnClosed += AdClosed;
            LoadInterstitialAd();


            sharedInstance.rewardedAd = new RewardedAd(sharedInstance.CurrentRewardedId);
    // Subscribe callback methods to load events:
            sharedInstance.rewardedAd.OnLoaded += RewardedAdLoaded;
            sharedInstance.rewardedAd.OnFailedLoad += RewardedAdFailedToLoad;

    // Subscribe callback methods to show events:
            sharedInstance.rewardedAd.OnShowed += RewardedAdShown;
            sharedInstance.rewardedAd.OnFailedShow += RewardedAdFailedToShow;
            sharedInstance.rewardedAd.OnUserRewarded += UserRewarded;
            sharedInstance.rewardedAd.OnClosed += RewardedAdClosed;

            LoadRewardedAd();

        }
    }

    void LoadInterstitialAd(){
        
        interstitialAd.Load();
    }

    void LoadRewardedAd(){
        
        rewardedAd.Load();
    }

    void Awake(){
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Called");
    }

    public void ShowInterstitialAd()
    {

        if (interstitialAd.AdState == AdState.Loaded)
        {
            interstitialAd.Show();
        }
    }


    public bool ShowRewardedVideo(MediationAdsDelegate callback)
    {
        if (rewardedAd.AdState == AdState.Loaded) {
            rewardedAd.Show();
            adsCallback = callback;
            return true;
        }
        else{
            adsCallback = null;
            return false;
        }

    }
/////////////////////////////////////////Interstitial Callbacks///////////////////////////////////////////////////////////

// Implement load event callback methods:
  void AdLoaded(object sender, EventArgs args) {
    Debug.Log("Ad loaded.");
    // Execute logic for when the ad has loaded
  }

  void AdFailedToLoad(object sender, LoadErrorEventArgs args) {
    Debug.Log("Ad failed to load.");
    LoadInterstitialAd();
    // Execute logic for the ad failing to load.
  }

  // Implement show event callback methods:
  void AdShown(object sender, EventArgs args) {
    Debug.Log("Ad shown successfully.");
    // Execute logic for the ad showing successfully.
  }

  void AdFailedToShow(object sender, ShowErrorEventArgs args) {
    Debug.Log("Ad failed to show.");
    LoadInterstitialAd();
    // Execute logic for the ad failing to show.
  }

  private void AdClosed(object sender, EventArgs e) {
    Debug.Log("Ad has closed");
    LoadInterstitialAd();
    // Execute logic after an ad has been closed.
  }


////////////////////////////////////////Rewarded Callbacks///////////////////////////////////////////////////////////

void RewardedAdLoaded(object sender, EventArgs args) {
    Debug.Log("Ad loaded.");
    // Execute logic for when the ad has loaded
  }

  void RewardedAdFailedToLoad(object sender, LoadErrorEventArgs args) {
    Debug.Log("Ad failed to load.");
    LoadRewardedAd();
    // Execute logic for the ad failing to load.
  }

  // Implement show event callback methods:
  void RewardedAdShown(object sender, EventArgs args) {
    Debug.Log("Ad shown successfully.");
    // Execute logic for the ad showing successfully.
  }

  void UserRewarded(object sender, RewardEventArgs args) {
    Debug.Log("Ad has rewarded user.");
    adsCallback(true);
    // Execute logic for rewarding the user.
  }

  void RewardedAdFailedToShow(object sender, ShowErrorEventArgs args) {
    Debug.Log("Ad failed to show.");
    adsCallback(false);
    LoadRewardedAd();
    // Execute logic for the ad failing to show.
  }

  void RewardedAdClosed(object sender, EventArgs e) {
    Debug.Log("Ad is closed.");
    LoadRewardedAd();
    // Execute logic for the user closing the ad.
  }
    public bool Check_Internet()
    {
       
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Time.timeScale = 0;
            Debug.Log("Error. Check internet connection!");
            if (_panelObject == null)
            {
                _panelObject = Instantiate(Resources.Load("panel/" + "NoInternetCanvas")) as GameObject;
            }
            return false;

        }
        else
        {
            if (_panelObject != null)
            {

                Destroy(_panelObject);
            }
            Debug.Log("Internet connection Avalible!");
            Time.timeScale = 1;
            return true;

        }

    }

}

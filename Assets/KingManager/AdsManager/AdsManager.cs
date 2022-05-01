using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Advertisements;
//using ChartboostSDK;

public class AdsManager : MonoBehaviour
{
    public delegate void AdsDelegate(bool isReward);

    AdsDelegate adsCallback;

    public KingSettings kingSettings;

    
    string SurfacingId;
    // ShowOptions options = new ShowOptions();

    public bool adStarted, adCompleted;
    public string myAdStatus;
    

    

    string adUnitId, adUnitIdRewarded;

    static AdsManager sharedInstance;

    public static AdsManager SharedInstance
    {
        get
        {
            if (!sharedInstance)
            {   
                GameObject obj = new GameObject("AdsManager");

                sharedInstance = obj.AddComponent<AdsManager>();
//                 sharedInstance.adsManagerSettings = Resources.Load<AdsManagerSettings>("AdsManagerSettings");
//                 DontDestroyOnLoad(sharedInstance);
//                 Debug.Log(sharedInstance.adsManagerSettings.Unity_Android_GameId);
// #if UNITY_ANDROID
//                 Advertisement.Initialize(sharedInstance.adsManagerSettings.Unity_Android_GameId, sharedInstance.adsManagerSettings.isTestMode);
//                 sharedInstance.SurfacingId = sharedInstance.adsManagerSettings.Unity_Android_Rewarded_AdUnitId;
// #else
//                 Advertisement.Initialize(sharedInstance.adsManagerSettings.Unity_iOS_GameId, sharedInstance.adsManagerSettings.isTestMode);
//                 sharedInstance.SurfacingId = sharedInstance.adsManagerSettings.Unity_IOS_Rewarded_AdUnitId;
// #endif
//                 Advertisement.Load(sharedInstance.SurfacingId);

                // Chartboost.Create();
                // Chartboost.cacheInterstitial(CBLocation.HomeScreen);
                // Chartboost.cacheRewardedVideo(CBLocation.HomeScreen);

                return sharedInstance;
            }
             return sharedInstance;
            
        }
    }

    public void Init(){

    }

    void Awake(){
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Called");
    }

   
    public void ShowAd()
    {
        // if (Advertisement.IsReady())
        // {
        //     Advertisement.Show();
        // }
        //else 
        //    Chartboost.showInterstitial(CBLocation.HomeScreen);

    }

    public void ShowUnityAd()
    {
        // if (Advertisement.IsReady())
        // {
        //     Advertisement.Show();
        // }

    }

    public void ShowChartboostAd()
    {
     //   Chartboost.showInterstitial(CBLocation.HomeScreen);
    }


    //===================rewarded Video===============================
    public bool ShowRewardedVideo(AdsDelegate callback)
    {

        Debug.Log("In ShowRewardedVideo");
        // Check if UnityAds ready before calling Show method:
return true;

    }

    // // Implement IUnityAdsListener interface methods:
    // public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    // {
    //     // Define conditional logic for each ad completion status:

    //     if (surfacingId == SurfacingId)
    //     {
    //         adCompleted = showResult == ShowResult.Finished;
    //         if (showResult == ShowResult.Finished)
    //         {
    //             adsCallback(true);
    //             // Reward the user for watching the ad to completion.
                
    //         }
    //         else if (showResult == ShowResult.Skipped)
    //         {
    //             // Do not reward the user for skipping the ad.
    //             Debug.Log("The ad skipped.");
    //             adsCallback(false);

    //         }
    //         else if (showResult == ShowResult.Failed)
    //         {
    //             Debug.LogWarning("The ad did not finish due to an error.");
    //             adsCallback(false);

    //         }
    //     }
               
    // }

    // public void OnUnityAdsReady(string surfacingId)
    // {
    //     // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
    //     if (surfacingId == SurfacingId)
    //     {
    //         // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
    //     }
    // }

    // public void OnUnityAdsDidError(string message)
    // {
    //     // Log the error.
    //     myAdStatus = message;
    // }

    // public void OnUnityAdsDidStart(string surfacingId)
    // {
    //     // Optional actions to take when the end-users triggers an ad.
    //     if (surfacingId == SurfacingId)
    //     {
    //         adStarted = true;
    //     }
    // }

}

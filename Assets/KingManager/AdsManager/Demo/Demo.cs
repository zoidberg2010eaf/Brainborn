using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        MediationManager.SharedInstance.Init();
        string[] titles = {"title1","title2","title3"};
        string[] description =  {"description1","description2","description3"};
        LocalNotificationManager.SharedInstance.SetUpNotifications(titles,description);
        
        Invoke("rate",10);
	}

    void rate(){
        AppReviewManager.Request();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showInterstitial(){
    	 MediationManager.SharedInstance.ShowInterstitialAd();
    }
    public void showRewarded(){
        if(MediationManager.SharedInstance.ShowRewardedVideo(RewardUser)){
            Debug.Log("Ad Shown");
        }
        else{
            Debug.Log("No Ads Available");
        }
    }

public void showInHouseFullAd(){
       InHouseAdManager.SharedInstance.ShowFullScreenAd();
    }

    void RewardUser(bool isRewarded){
        if(isRewarded){
            Debug.Log("User Rewarded");
        }
        else{
            Debug.Log("Not Rewarded");
        }
    }
    //////////////////////////////Alert Demo/////////////////////////////

    public void ShowAlertWithTextAndButtons(){
        AlertManager.SharedInstance.ShowAlertWithText("hello Its Alert With Buttons",ok,cancel);
    }

    public void ShowAlertWithoutButtonsAndtimeout(){
        AlertManager.SharedInstance.ShowAlertWithoutButtonsAndtimeout("hello Its Alert Without Buttons\n Auto set hide in 5 sec",5);
    }

void cancel(){

}
void ok(){

}


}

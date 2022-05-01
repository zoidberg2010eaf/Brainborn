using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "KingSettings", menuName = "KingManager/KingSettings", order = 1)]
public class KingSettings : ScriptableObject
{


	//public bool isTestMode = true;

    public string Unity_iOS_GameId = "4505676";
    public string Unity_Android_GameId = "4505677";

    
    public string Unity_Android_Interstitial_AdUnitId = "Interstitial_Android";
    public string Unity_IOS_Interstitial_AdUnitId = "Interstitial_iOS";
    public string Unity_Android_Rewarded_AdUnitId = "Rewarded_Android";
    public string Unity_IOS_Rewarded_AdUnitId = "Rewarded_iOS";
    public string Unity_Android_Banner_AdUnitId = "Banner_Android";
    public string Unity_IOS_Banner_AdUnitId = "Banner_iOS";
    public int InHouse_Ad_Small_Id = 1;

    public int InHouse_Ad_FullScreen_Id = 2;


    public Texture Notification_Small_Icon;
    public Texture Notification_Large_Icon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

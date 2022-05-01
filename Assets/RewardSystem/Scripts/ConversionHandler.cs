using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversionHandler : MonoBehaviour
{
    
    public string GroupLink;
    public Toggle joinGroupToggle;
    public Text gemsText;
    public InputField usernameInput, gemsInput;
    public GameObject popupMsg, popupMsgJoinGroup, popupMsgFillFields, popupMsgNotEnoghCoins;
    public static ConversionHandler sharedInstance;
    int totalGems;

    private void Awake()
    {
        sharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gemsInput.characterValidation = InputField.CharacterValidation.Integer;
        totalGems = RewardManager.SharedInstance.totalGems;
        gemsText.text = "Total gems: "+totalGems;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetGemsText(int gems)
    {
        gemsText.text = "Total gems: " + gems;
        totalGems = gems;
    }
    public void Convert()
    {
        if (joinGroupToggle.isOn)
        {
            string totalgems = gemsText.text;
            string username = usernameInput.text;
            
            string gems = gemsInput.text;
            string deviceID = SystemInfo.deviceUniqueIdentifier;
#if UNITY_EDITOR
            {
                deviceID = deviceID.Substring(0, 15);
            }
#endif
            Debug.Log("totalgems: " + totalgems + ", username: " + username + ", gems: " + gems);
            if (username != "" && gems != "")
            {
                if (int.Parse(gems) > totalGems)
                {
                    popupMsgNotEnoghCoins.SetActive(true);
                }
                else
                {
                    string[] values = { deviceID, gems.ToString(), username };
                    RewardManager.SharedInstance.ExchangeGems(values);
                    popupMsg.SetActive(true);
                }
                
            }
            else
            {
                popupMsgFillFields.SetActive(true);
            }
           
        }
        else
        {
            popupMsgJoinGroup.SetActive(true);
        }
        
    }
    public void OpenGroupLink()
    {
        Application.OpenURL(GroupLink);
    }
    public void Back()
    {
        RewardManager.SharedInstance.GetUserData();
        Destroy(gameObject);
    }
}

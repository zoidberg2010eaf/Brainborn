using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashHandler : MonoBehaviour
{
    [Tooltip("Terms Link")]
    public string termsLink; 
    [Tooltip("privacy Link")]
    public string privacyLink;

    public GameObject screen1, screen2, screen3, screen4;
    public Image fillImage;
    public Slider sliderr;

    public Toggle privacyCheck,maleCheck, femaleCheck;
    public InputField userName;
    public GameObject userNameError;

    int robuxToEarn;
    AsyncOperation asyncLoad;
    int RStatus;
    // Start is called before the first frame update
   /* void Start()
    {
        // check internet
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("no internet");
        }
        else
        {

            Debug.Log("available network");
        }
        if (PlayerPrefs.GetInt("privacyCheckAccepted")==0)
        {
            privacyCheck.interactable = true;
        }
        else
        {
            privacyCheck.interactable = false;
        }
        //RewardManager.SharedInstance.GetAppReviewStatusById();
        RewardManager.SharedInstance.GetStatusById();
        Debug.Log("robuxToEarn: " + PlayerPrefs.GetInt("robuxToEarn"));
        MediationManager.SharedInstance.Init();
        screen1.SetActive(true);
        StartCoroutine(WaitForLoadScene());
    }*/

   IEnumerator Start()
   {
       UIEvent ui = FindObjectOfType<UIEvent>();
       bool hasInternet = false;
       if (Application.internetReachability == NetworkReachability.NotReachable)
       {
           hasInternet = false;
           Debug.Log("no internet");
       }
       else
       {
           hasInternet = true;
           Debug.Log($"available network");
       }
       
       privacyCheck.interactable = PlayerPrefs.GetInt("privacyCheckAccepted")==0;

       yield return new WaitWhile(() => ui.TenjinActive);
       //If there is no internet connection
       if (!hasInternet)
       {
           //If the ReviewStatus key has not been set before
           if(!PlayerPrefs.HasKey("ReviewStatus")) PlayerPrefs.SetInt("ReviewStatus", 0);
       }
       else
       {
           //Get StatusResponse Everytime an Internet connection is available
           RewardManager.SharedInstance.GetStatusById();
           //yield return new WaitUntil(() => PlayerPrefs.HasKey("StatusResponse"));
           //If no data exists on the Server for the UserID
           if (PlayerPrefs.GetInt("StatusResponse") == -1)
           {
               //Set StatusResponse to the Value of ReviewStatus
               PlayerPrefs.SetInt("StatusResponse", PlayerPrefs.GetInt("ReviewStatus"));
               //Add a new entry to the Server
               RewardManager.SharedInstance.SetStatusById();
           }
           else
           {
               //If StatusResponse is not -1 and is not the same as ReviewStatus
               if (PlayerPrefs.GetInt("ReviewStatus") != PlayerPrefs.GetInt("StatusResponse"))
               {
                   //Set ReviewStatus to the Value of StatusResponse
                   PlayerPrefs.SetInt("ReviewStatus", PlayerPrefs.GetInt("StatusResponse"));
               }
           }
       }
       
       Debug.Log("robuxToEarn: " + PlayerPrefs.GetInt("robuxToEarn"));
       MediationManager.SharedInstance.Init();
       screen1.SetActive(true);
       StartCoroutine(WaitForLoadScene());
   }
   
   
   
    /*void Start(){
        bool hasInternet = false;
        // check internet
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("no internet");
            if (!PlayerPrefs.HasKey("ReviewStatus"))
            {
                PlayerPrefs.SetInt("ReviewStatus", 0);
            }
        }
        else
        {
            hasInternet = true;
            RewardManager.SharedInstance.GetStatusById();
            Debug.Log($"available network {PlayerPrefs.GetInt("StatusResponse")}");
        }
        if (PlayerPrefs.GetInt("privacyCheckAccepted")==0)
        {
            privacyCheck.interactable = true;
        }
        else
        {
            privacyCheck.interactable = false;
        }
        
        if (hasInternet && !PlayerPrefs.HasKey("ReviewStatus"))
        {
            Debug.Log("hohohoho");
            if (!PlayerPrefs.HasKey("StatusResponse") || PlayerPrefs.GetInt("StatusResponse") == -1)
            {
                Debug.Log("hwhwwhw");
                Debug.Log("brooooooooooo ");
                // Set the UI to the new one and save the user data to the server
                Debug.Log("setting Status to 0");
                PlayerPrefs.SetInt("ReviewStatus", 0);
                RewardManager.SharedInstance.SetStatusById();
                // If it exists on the server
            }
        }
        else
        {
            Debug.Log("hshshshs");
            Debug.Log(PlayerPrefs.GetInt("StatusResponse"));
            int resp = PlayerPrefs.GetInt("StatusResponse");
            if (resp == -1)
            {
                PlayerPrefs.SetInt("StatusResponse", PlayerPrefs.GetInt("ReviewStatus"));
            }
            else
            {
                PlayerPrefs.SetInt("ReviewStatus", resp);
            }
            //Set the local Status to the one on the Server
            
        }
        
        
        Debug.Log("robuxToEarn: " + PlayerPrefs.GetInt("robuxToEarn"));
        MediationManager.SharedInstance.Init();
        screen1.SetActive(true);
        StartCoroutine(WaitForLoadScene());
    }*/

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("StatusResponse"));
    }
    IEnumerator WaitForLoadScene()
    {
        asyncLoad = SceneManager.LoadSceneAsync("MainScene");
        asyncLoad.allowSceneActivation = false;

        while (fillImage.fillAmount < 1 && !asyncLoad.isDone)
        {
            fillImage.fillAmount += Time.deltaTime / 10;
            //float amount = (Mathf.Round(fillImage.fillAmount * 1000) / 1000) * 100;
            //Loading_Progress_text.text = "" + (amount).ToString() + " %";
            yield return null;
        }
        RStatus= PlayerPrefs.GetInt("ReviewStatus");
        if (RStatus == 1) // isreviewed
        {
            if (PlayerPrefs.GetInt("isFirstTimeStart") == 0)
            {
                screen1.SetActive(false);
                screen2.SetActive(true);
            }
            else
            {
                asyncLoad.allowSceneActivation = true;
            }
        }
        else
        {
            asyncLoad.allowSceneActivation = true;
        }

    }
    public void EnableThirdScreen()
    {
        screen2.SetActive(false);
        screen3.SetActive(true);
    }
    public void SetRobuxTxt(Text valueTxt)
    {
        valueTxt.text = "" + (int)sliderr.value;
    }
    public void Continue()
    {
        robuxToEarn = (int)sliderr.value;
        PlayerPrefs.SetInt("robuxToEarn", robuxToEarn);
        int coinsToGiveAtStart = (int)(0.6f * robuxToEarn);
        Debug.Log("robuxToEarn: " + robuxToEarn);
        Debug.Log("coinsToGiveAtStart: "+coinsToGiveAtStart);
        //PlayerPrefs.SetInt("Totalcoins", coinsToGiveAtStart);

        //ADD POINTS
        RewardManager.SharedInstance.AddPoints(coinsToGiveAtStart);


        screen3.SetActive(false);
        screen4.SetActive(true);
    }
    public void ClearUserName()
    {
        userName.text = "";
    }
    public void StartGame()
    {
        if (userName.text == "")
        {
            userNameError.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetString("userName", userName.text);
            PlayerPrefs.SetInt("isFirstTimeStart", 1);
            asyncLoad.allowSceneActivation = true;
        }
       
    }
    public void SelectGenderFemale()
    {
        if (femaleCheck.isOn)
        {
            maleCheck.isOn = false;
            PlayerPrefs.SetString("Gender", "Female");
        }
    }
    public void SelectGenderMale()
    {
       if (maleCheck.isOn)
        {
            femaleCheck.isOn = false;
            PlayerPrefs.SetString("Gender", "Male");
        }
    }
    public void TermsAndPrivacyCheck()
    {
        if (!privacyCheck.isOn)
        {
            PlayerPrefs.SetInt("privacyCheckAccepted", 0);
            Application.Quit();
        }
        else
        {
            PlayerPrefs.SetInt("privacyCheckAccepted", 1);
        }
    }
    public void OPenTermsLink()
    {
        Application.OpenURL(termsLink);
    }
    public void OPenPrivacyLink()
    {
        Application.OpenURL(privacyLink);
    }

}

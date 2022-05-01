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
    void Start()
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
        RewardManager.SharedInstance.GetAppReviewStatusById();
        Debug.Log("robuxToEarn: " + PlayerPrefs.GetInt("robuxToEarn"));
        MediationManager.SharedInstance.Init();
        screen1.SetActive(true);
        StartCoroutine(WaitForLoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
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

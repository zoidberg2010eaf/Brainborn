using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InHouseAdSmall : MonoBehaviour
{
     public KingSettings kingSettings;
    InHouseAdObject adObject;
    public Image inhouseAdImage;
    public Text inhouseAdText;
    // Start is called before the first frame update
    void Start()
    {
        kingSettings = Resources.Load<KingSettings>("KingSettings");
        inhouseAdImage.color = new Color(1,1,1,0);
        foreach(Transform tr in inhouseAdImage.transform)
        {
            tr.gameObject.SetActive(false);
        }
        WebRequestManager.SharedInstance.GetInHouseAdWebRequest(""+kingSettings.InHouse_Ad_Small_Id,WebRequestCallback);

    }

    void WebRequestCallback(string data){
        Debug.Log(data);
        adObject =  JsonUtility.FromJson<InHouseAdObject>(data);
        loadAdImage(adObject);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void loadAdImage(InHouseAdObject adObject){
        inhouseAdText.text = adObject.title;
         Davinci.get()
        .load(adObject.image)
        .setFadeTime(2) // 0 for disable fading
        .into(inhouseAdImage)
        .setCached(true)
        .withStartAction(() =>
        {
            Debug.Log("Download has been started.");
        })
        .withDownloadProgressChangedAction((progress) =>
        {
            Debug.Log("Download progress: " + progress);
        })
        .withDownloadedAction(() =>
        {
            Debug.Log("Download has been completed.");
            inhouseAdImage.color = Color.white;
            foreach(Transform tr in inhouseAdImage.transform)
            {
                tr.gameObject.SetActive(true);
            }
        })
        .withLoadedAction(() =>
        {
            Debug.Log("Image has been loaded.");
        })
        .withErrorAction((error) =>
        {
            Debug.Log("Got error : " + error);
        })
        .withEndAction(() =>
        {
            Debug.Log("Operation has been finished.");
        })
        .start();
    }
    public void OpenURL(){
        if(adObject != null){
#if UNITY_ANDROID
            Application.OpenURL(adObject.urlAndroid);
#else
            Application.OpenURL(adObject.urliOS);
#endif
        }
    } 
}


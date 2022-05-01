using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InHouseAdFullScreen : MonoBehaviour
{
    public KingSettings kingSettings;
    InHouseAdObject adObject;
    public Image inhouseAdImage;
    public Text inhouseAdTitleText;
    public Text inhouseAdDscriptionText;
    // Start is called before the first frame update
    void Start()
    {
        kingSettings = Resources.Load<KingSettings>("KingSettings");
        inhouseAdImage.color = new Color(1,1,1,0);
        foreach(Transform tr in transform)
        {
            tr.gameObject.SetActive(false);
        }
        WebRequestManager.SharedInstance.GetInHouseAdWebRequest(""+kingSettings.InHouse_Ad_FullScreen_Id,WebRequestCallback);

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
        inhouseAdTitleText.text = adObject.title;
        inhouseAdDscriptionText.text = adObject.description;
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
            foreach(Transform tr in transform)
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
            gameObject.SetActive(false);
            Destroy(gameObject, 1);
        }
    } 
    public void ClosePressed(){
        gameObject.SetActive(false);
        Destroy(gameObject, 1);
    }
}


public class InHouseAdObject{
    public int id;
    public string title;
    public string description;
    public string image;
    public string urliOS;
    public string urlAndroid;

}
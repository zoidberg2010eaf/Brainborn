using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Security.Cryptography.X509Certificates;

class AcceptAllCertificatesSignedWithASpecificKeyPublicKey : CertificateHandler
{
    // Encoded RSAPublicKey

    protected override bool ValidateCertificate(byte[] certificateData)
    {
        

            return true;

       
    }
}


public class WebRequestManager : MonoBehaviour
{
    const string BaseURL = "https://thekingstudios.com/InhouseAdsAPI/";
    public delegate void WebRequestDelegate(string str);

    private static WebRequestManager sharedInstance;
    public static WebRequestManager SharedInstance
    {
        get
        {
            if (!sharedInstance)
            {
                GameObject webrequestObject = new GameObject("WebRequestManager");
                sharedInstance = webrequestObject.AddComponent<WebRequestManager>();
            }
            return sharedInstance;
        }
    }

    public void GetInHouseAdWebRequest (string adId , WebRequestDelegate callback) {
        
        StartCoroutine(GetRequest(BaseURL+"getAdWithId","id",adId, callback));
    }

    IEnumerator GetRequest(string uri, string header,string headerValue, WebRequestDelegate callback)
    {



        var request = new UnityWebRequest (uri, "GET");
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.certificateHandler = new AcceptAllCertificatesSignedWithASpecificKeyPublicKey();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader(header, headerValue);
        yield return request.SendWebRequest();

        if (request.error != null)
        {
            Debug.Log("Erro: " + request.error);
        }
        else
        {
            Debug.Log("All OK");
            Debug.Log("Status Code: " + request.downloadHandler.text);
            callback(request.downloadHandler.text);
        }

        
    }

}

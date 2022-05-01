using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Security.Cryptography.X509Certificates;

class AcceptAllCertificatesSignedWithASpecificKeyPublicKey1 : CertificateHandler
{
    // Encoded RSAPublicKey

    protected override bool ValidateCertificate(byte[] certificateData)
    {
        

            return true;

       
    }
}


public class WebRequestManagerReward : MonoBehaviour
{
    const string BaseURL = "http://31.220.108.49:8080/roblex/";
    public delegate void WebRequestDelegate(string str);

    private static WebRequestManagerReward sharedInstance;
    public static WebRequestManagerReward SharedInstance
    {
        get
        {
            if (!sharedInstance)
            {
                GameObject webrequestObject = new GameObject("WebRequestManagerReward");
                sharedInstance = webrequestObject.AddComponent<WebRequestManagerReward>();
            }
            return sharedInstance;
        }
    }

    public void GetUserDataWebRequest(string[] hesderValues, WebRequestDelegate callback)
    {
        string[] headers = { "id"};
        StartCoroutine(GetRequest(BaseURL + "getUserWithId", headers, hesderValues, callback));
    }
    public void GetAddPointsWebRequest (string[] hesderValues , WebRequestDelegate callback) {
        string[] headers = { "id", "points", "bundleId" };
        StartCoroutine(GetRequest(BaseURL+"addPoints", headers, hesderValues, callback));
        
    }

    public void GetExchangeWebRequest(string[] hesderValues, WebRequestDelegate callback)
    {
        string[] headers = { "id", "points", "robloxUsername" };
        StartCoroutine(GetRequest(BaseURL + "requestExcahnge", headers, hesderValues, callback));
    }
    public void GetAppReviewStatus(string[] hesderValues, WebRequestDelegate callback)
    {
        string[] headers = { "bundleid" };
        StartCoroutine(GetRequest(BaseURL + "getAppWithBundleId", headers, hesderValues, callback));
    }

    IEnumerator GetRequest(string uri, string[] header,string[] headerValue, WebRequestDelegate callback)
    {
        yield return new WaitUntil(() => (MediationManager.SharedInstance.Check_Internet() == true));

            var request = new UnityWebRequest(uri, "GET");
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.certificateHandler = new AcceptAllCertificatesSignedWithASpecificKeyPublicKey();
            request.SetRequestHeader("Content-Type", "application/json");
            for (int i = 0; i < header.Length; i++)
            {
                request.SetRequestHeader(header[i], headerValue[i]);
            }
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

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class DLEvent : UnityEvent<Dictionary<string, string>> { }

public class TenjinManager : MonoBehaviour
{
    private BaseTenjin _instance;

    public UnityEvent onNewUser;

    public DLEvent deepLinkReceived;
    // Start is called before the first frame update
    void Awake()
    {
        TenjinConnect();
        //Application.deepLinkActivated += s => _instance.SendEvent("heeeey");
        _instance.GetDeeplink(OnDeepLinkActivated);
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onNewUser?.Invoke();
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus)
        {
            TenjinConnect();
        }
    }

    void OnDeepLinkActivated(Dictionary<string, string> data)
    {
        deepLinkReceived?.Invoke(data);
        if (data.ContainsKey("is_first_session") && data.ContainsKey("clicked_tenjin_link"))
        {
            _instance.SendEvent($"is_first_session:{data["is_first_session"]}   clicked_tenjin_link:{data["clicked_tenjin_link"]}");
            //_instance.SendEvent($"{string.Join(",", data.Keys)}");
            //_instance.SendEvent($"{string.Join(",", data.Values)}");
            if (data["is_first_session"].ToLower() == "true" && data["clicked_tenjin_link"].ToLower() == "true")
            {
                //TODO It's confusing because new users has no deffered deeplink, while it should.
                if (!data.ContainsKey("deferred_deeplink_url") && !data.ContainsKey("ad_network"))
                {
                    Debug.Log("doesn't contain deeplink");
                    //_instance.SendEvent("doesn't contain deeplink");
                    onNewUser?.Invoke();
                }
                else
                {
                    _instance.SendEvent("contains deeplink");
                }
            }
            else
            {
                if (!PlayerPrefs.HasKey("ReviewStatus"))
                {
                    PlayerPrefs.SetInt("ReviewStatus", 0);
                    RewardManager.SharedInstance.SetStatusById();
                }
               
            }
        }
    }

    private void OnDestroy()
    {
        onNewUser?.RemoveAllListeners();
        deepLinkReceived?.RemoveAllListeners();
    }

    private void TenjinConnect()
    {
        _instance = Tenjin.getInstance("LGVF2THTXBL3FTTPQKYUTOZISVOBSDPC");

        _instance.SetAppStoreType(AppStoreType.googleplay);

#if UNITY_IOS
        if (new Version(UnityEngine.iOS.Device.systemVersion).CompareTo(new Version("14.0")) >= 0) {
            // Tenjin wrapper for requestTrackingAuthorization
            _instance.RequestTrackingAuthorizationWithCompletionHandler((status) => {
                Debug.Log("===> App Tracking Transparency Authorization Status: " + status);

                // Sends install/open event to Tenjin
                _instance.Connect();

            });
        }
        else {
            _instance.Connect();
        }
#elif UNITY_ANDROID

        // Sends install/open event to Tenjin
        _instance.Connect();

#endif

    }
}

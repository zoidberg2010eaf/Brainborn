using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#else
using Unity.Notifications.iOS;
#endif

public class LocalNotificationManager : MonoBehaviour
{



    static LocalNotificationManager sharedInstance;
    public static LocalNotificationManager SharedInstance
    {
        get
        {
            if (!sharedInstance)
            {
                GameObject obj = new GameObject("LocalNotificationManager");
                sharedInstance = obj.AddComponent<LocalNotificationManager>();
            }
            return sharedInstance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpNotifications(string[] title, string[] description){
        int i = 0;
#if UNITY_ANDROID
        AndroidNotificationCenter.CancelAllNotifications();

        var channel = new AndroidNotificationChannel()
        {
            Id = "Kings_Channel",
            Name = "Kings Channel",
            Importance = Importance.Default,
            Description = "Game Notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
        
        while(i<title.Length){
            
            var notification = new AndroidNotification();
            notification.Title = title[i];
            notification.Text = description[i];
            notification.FireTime = System.DateTime.Now.AddDays((int)(i+1)*1.5f);
            //notification.FireTime = System.DateTime.Now.AddMinutes((int)(i+1)*1.5f);

            notification.SmallIcon = "my_custom_icon_id";

            AndroidNotificationCenter.SendNotification(notification, "Kings_Channel");
            i++;
        }
    }
#else
        //StartCoroutine(RequestAuthorization());
        i=0;
       // iOSNotificationCenter.RemoveAllScheduledNotifications();
      //  iOSNotificationCenter.RemoveAllDeliveredNotifications();
        while(i<title.Length){
            float f = ((i+1) * 1.5f);
            var timeTrigger = new iOSNotificationTimeIntervalTrigger()
            {
                
                //TimeInterval = new TimeSpan(24 * ((int)f), 0, 0),
                TimeInterval = new TimeSpan((i+1)*60*60*24),
                Repeats = false
            };
            
            var notificationiOS = new iOSNotification()
            {
                // You can optionally specify a custom identifier which can later be 
                // used to cancel the notification, if you don't set one, a unique 
                // string will be generated automatically.
                Identifier = "_notification_01",
                Title = title[i],
                Body = description[i],
                Subtitle = title[i],
                ShowInForeground = true,
                ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
                CategoryIdentifier = "category_a",
                ThreadIdentifier = "thread1",
                Trigger = timeTrigger,
            };
            iOSNotificationCenter.ScheduleNotification(notificationiOS);
            i++;
        }
    }

    IEnumerator RequestAuthorization()
    {
        using (var req = new AuthorizationRequest(AuthorizationOption.Alert | AuthorizationOption.Badge | AuthorizationOption.Sound, true))
        {
            while (!req.IsFinished)
            {
                yield return null;
            };

            string res = "\n RequestAuthorization: \n";
            res += "\n finished: " + req.IsFinished;
            res += "\n granted :  " + req.Granted;
            res += "\n error:  " + req.Error;
            res += "\n deviceToken:  " + req.DeviceToken;
            Debug.Log(res);
        }
    }

#endif


   
}

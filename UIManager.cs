using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.DynamicLinks;
using Firebase.Extensions;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text userType;
    [SerializeField] private SpriteRenderer circle;
    DependencyStatus dependencyStatus;
    public bool firebaseInitialized = false;
    // Start is called before the first frame update
    void Start()
    {
        dependencyStatus = DependencyStatus.UnavailableOther;
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available) {
                InitializeFirebase();
            } else {
                Debug.LogError(
                    $"Could not resolve all Firebase dependencies: {dependencyStatus}");
            }
        });
    }
    
    void OnDynamicLink(object sender, EventArgs args) {
        var dynamicLinkEventArgs = args as ReceivedDynamicLinkEventArgs;
        var queries = HttpUtility.ParseQueryString(dynamicLinkEventArgs.ReceivedDynamicLink.Url.Query);
        userType.text = int.Parse(queries.Get("new_user")) == 0? "Old" : "New";
        circle.color = int.Parse(queries.Get("curr_ui")) == 0 ? Color.red : Color.green;
        Debug.Log($"Received dynamic link {dynamicLinkEventArgs?.ReceivedDynamicLink.Url.OriginalString}");
    }
    
    void InitializeFirebase() {
        DynamicLinks.DynamicLinkReceived += OnDynamicLink;
        firebaseInitialized = true;
    }

    void OnDestroy() {
        DynamicLinks.DynamicLinkReceived -= OnDynamicLink;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

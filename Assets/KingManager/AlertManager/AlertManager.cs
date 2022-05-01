using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertManager : MonoBehaviour
{
    // Start is called before the first frame update
    static AlertManager sharedInstance;

    public static  AlertManager SharedInstance
    {
        get
        {
            if (!sharedInstance)
            {   
                GameObject obj = new GameObject("AlertManager");

                sharedInstance = obj.AddComponent<AlertManager>();
                DontDestroyOnLoad(sharedInstance);
                return sharedInstance;
            }
             return sharedInstance;
            
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAlertWithText(string text,AlertController.AlertControllerOKDelegate okcallback,AlertController.AlertControllerCancelDelegate cancelCallback){
        //GameObject obj = Resources.Load<GameObject>("AlertPanel");
        GameObject instance = Instantiate(Resources.Load("AlertCanvas", typeof(GameObject))) as GameObject;
        instance.GetComponent<AlertController>().ShowAlert(text,okcallback,cancelCallback);
    }
    public void ShowAlertWithoutButtonsAndtimeout(string text,int timeout){
        //GameObject obj = Resources.Load<GameObject>("AlertPanel");
        GameObject instance = Instantiate(Resources.Load("AlertCanvas", typeof(GameObject))) as GameObject;
        instance.GetComponent<AlertController>().ShowAlertWithoutButtonsAndtimeout(text,timeout);
    }
}

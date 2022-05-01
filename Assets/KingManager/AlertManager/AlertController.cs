using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertController : MonoBehaviour
{

    public delegate void AlertControllerOKDelegate();
    public delegate void AlertControllerCancelDelegate();

    AlertControllerOKDelegate okCallback;
    AlertControllerCancelDelegate cancelCallback;

    public GameObject AlertView;
    public Button OKButton;
    public Button CancelButton;
    public Text AlertTextView;




    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OKButtonPressed(){
        AlertView.SetActive(false);
        if(okCallback != null)
            okCallback();
        Destroy(gameObject, 1);
    }
    public void CancelButtonPressed(){
        AlertView.SetActive(false);
        if(cancelCallback != null)
           cancelCallback();
        Destroy(gameObject, 1);

    }

    public void ShowAlert(string text, AlertControllerOKDelegate okcallback, AlertControllerCancelDelegate cancelcallback){
        AlertTextView.text = text;
        okCallback = okcallback;
        cancelCallback = cancelcallback;
        AlertView.SetActive(true);
    }

    public void ShowAlertWithoutButtonsAndtimeout(string text, int timeout){
        AlertTextView.text = text;
        AlertView.SetActive(true);
        OKButton.gameObject.SetActive(false);
        CancelButton.gameObject.SetActive(false);
        Invoke("hideAlert",timeout);
    }

    public void hideAlert(){
        AlertView.SetActive(false);
        Destroy(gameObject, 1);
    }





}

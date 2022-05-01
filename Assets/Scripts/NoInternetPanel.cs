using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoInternetPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void No_Internet_Panel_Okay()
    {
        MediationManager.SharedInstance.Check_Internet();
     
    }

}

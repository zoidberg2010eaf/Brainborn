using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCoinsUIHandler : MonoBehaviour
{
    public GameObject addPoints_panel;
    public Text gemsTxt;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnableAddPointsPanel()
    {
        addPoints_panel.SetActive(true);
    }
    public void AddPoints()
    {
       
        RewardManager.SharedInstance.AddPoints(int.Parse(gemsTxt.text));
        addPoints_panel.SetActive(false);
    }
}

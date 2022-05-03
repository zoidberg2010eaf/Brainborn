using System.Collections.Generic;
using UnityEngine;

public class UIEvent : MonoBehaviour
{
    private LevelPanel _panel;
    public bool TenjinActive { get; private set; }
    public void Start()
    {
        /*_panel = GameObject.FindObjectOfType<LevelPanel>();
        if (PlayerPrefs.HasKey("ReviewStatus"))
        {
            if (PlayerPrefs.GetInt("newUser") == 1)
            {
                //_panel.bgImg.color = Color.red;
            }
        }
        else
        {
            PlayerPrefs.SetInt("newUser", 0);
        }*/
    }

    public void ChangeUi()
    {
        // User is coming from a Tenjin tracking link and has no attribution saved
        // Check if the local app has Status saved (Means the game is on the phone)
        // If not
        TenjinActive = true;
        if (!PlayerPrefs.HasKey("ReviewStatus"))
        {
            // Check for it on server
            RewardManager.SharedInstance.GetStatusById();
            // If it doesn't exist
            if (PlayerPrefs.GetInt("StatusResponse") == -1)
            {
                // Set the UI to the new one and save the user data to the server
                PlayerPrefs.SetInt("ReviewStatus", 1);
                RewardManager.SharedInstance.SetStatusById();
            }
            // If it exists on the server
            else
            {
                //Set the local Status to the one on the Server
                PlayerPrefs.SetInt("ReviewStatus", PlayerPrefs.GetInt("StatusResponse"));
            }
            PlayerPrefs.Save();
        }
        TenjinActive = false;
        
    }

    public void OnNewUser(Dictionary<string, string> data)
    {
        
    }

}
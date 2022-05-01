using UnityEngine;

public class UIEvent : MonoBehaviour
{
    private LevelPanel _panel;
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
        //_panel.bgImg.color = Color.red;
        PlayerPrefs.SetInt("ReviewStatus", 1);
        PlayerPrefs.Save();
    }

}
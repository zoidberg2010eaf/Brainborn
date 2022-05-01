using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuidePanel : UIPanelBase
{
    public Text tipslableText;

    public Text tipsContentText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void UpdateText()
    {
        tipsContentText.text = GleyLocalization.Manager.GetText("WinTips" + LevelManager._Instance.currentLevel);
        tipslableText.text = GleyLocalization.Manager.GetText("TipLabel");
    }

    public override void Hide()
    {
        UIPanelManager._Insance.HidePanel("GuidePanel");
    }
}

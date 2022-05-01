using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : UIPanelBase
{
	[SerializeField]
	private Button _NextBtn;

	[SerializeField]
	private Button _GetKeyBtn;

	public Text _WinGuideText;

	public Text nextText;

	public Text titleText;

	public Text rankLvText;

	[SerializeField]
	private Image manImg;


	[SerializeField]
	private RectTransform titleImg;


	[SerializeField]
	private Transform tempTrans;

	[SerializeField]
	private Transform btnTrans;

	[SerializeField]
	private Transform ranTran;

	[SerializeField]
	private Image[] buttonImgs;

	private Sprite[] btnSprites;

	[SerializeField]
	private RectTransform conTran;

	[SerializeField]
	private RectTransform clapTran;

	[SerializeField]
	private RectTransform clapTarget;

	private Tweener ConTweener;

	private Tweener ClapTweener;

	private int index;

	private static bool isExit;

	

	private float oriAnPosY;

	private float curBottom;

	private void Start()
	{
		AudioManager._Instance.PlaySound("gameplay_win1");
		UpdatePanel();
	}

	public override void Escape()
	{

	}

	public void NextBtnClick()
	{
		LevelManager._Instance.currentLevel++;
		if (LevelManager._Instance.currentLevel >= 50)
			LevelManager._Instance.currentLevel -= 50;
		PlayerPrefs.SetInt("CurrentLevel", LevelManager._Instance.currentLevel - 1);
		UIPanelManager._Insance.ShowPanel("PlayPanelSimple");
		LevelManager._Instance.LoadLevel();
	}

	private void KeyBtnClick()
	{
	}

	private IEnumerator UpdateAdState()
	{
		return null;
	}

	private void UpdateAdStatus(bool status)
	{
	}

	public override void Show()
	{
	}

	protected override void UpdateShareRect()
	{
	}

	public override void Show(object para)
	{
	}

	public override void Hide()
	{
	}

	public override void UpdateText()
	{
		_WinGuideText.text = GleyLocalization.Manager.GetText("WinGuide" + LevelManager._Instance.currentLevel);
		titleText.text = GleyLocalization.Manager.GetText("WinTitle");
		nextText.text = GleyLocalization.Manager.GetText("WinNext");
		rankLvText.text = "lvl." + LevelManager._Instance.currentLevel;
	}

	public override void UpdatePanel()
	{
		UpdateText();
		if(LevelManager._Instance.currentLevel >= LevelManager._Instance._unlockLevel)
		{
			LevelManager._Instance._unlockLevel++;
			PlayerPrefs.SetInt("UnlockLevel", LevelManager._Instance._unlockLevel -1);
		}
	}


	public void FreeBtnClick()
	{
		//AdmobAd2.instance.ShowRewardedAd();
		if (MediationManager.SharedInstance.ShowRewardedVideo(RewardUser))
		{
			Debug.Log("Ad Shown");
		}
		else
		{
			Debug.Log("No Ads Available");
		}
	}
	void RewardUser(bool isRewarded)
	{
		if (isRewarded)
		{
			GameManager._Instance._Tips++;
			PlayerPrefs.SetInt("Tips", GameManager._Instance._Tips);
			Debug.Log("User Rewarded");
		}
		else
		{
			Debug.Log("Not Rewarded");
		}
	}

}

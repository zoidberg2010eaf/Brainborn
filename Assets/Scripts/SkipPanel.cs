using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipPanel : UIPanelBase
{
	

	[SerializeField]
	private RectTransform ScaleContent;

	[SerializeField]
	private RectTransform topContent;

	public Text _GuideText;

	public Text _titleText;

	public Text skipText;

	

	[SerializeField]
	private RectTransform titleImg;

	[SerializeField]
	private RectTransform backBtnTran;

	[SerializeField]
	private Image[] buttonImgs;

	private Sprite[] btnSprites;

	[SerializeField]
	private Transform tempContent;

	

	private bool isCanSkip;

	private bool updateShow;

	private Tweener tweener;

	[SerializeField]
	private Transform doubleBtnContent;

	

	[SerializeField]
	private GameObject redMark;

	public static int AdJustIndex;

	private int passAd;

	private void Start()
	{
		UpdateText();
	}

	public void UpdateRedMark(bool value)
	{
	}

	private IEnumerator UpdateAdState()
	{
		return null;
	}

	private void UpdateAdStatus(bool status)
	{
	}

	public void SkipBtnClick()
	{
		if (GameManager._Instance._Tips >= 2)
		{
			GameManager._Instance._Tips -= 2;
			PlayerPrefs.SetInt("Tips", GameManager._Instance._Tips);

			LevelManager._Instance.currentLevel++;
			PlayerPrefs.SetInt("CurrentLevel", LevelManager._Instance.currentLevel - 1);
			if (PlayerPrefs.GetInt("ReviewStatus") == 1)
			{
				UIPanelManager._Insance.ShowPanel("PlayPanel");
			}
			else
			{
				UIPanelManager._Insance.ShowPanel("PlayPanelSimple");
			}
			LevelManager._Instance.LoadLevel();
		}
		else
        {
			UIPanelManager._Insance.HidePanel("SkipPanel");
			UIPanelManager._Insance.ShowPanel("ShopPanel");
		}			
			

		PlayPanel._Instance.UpdateTips();
	}


	public override void Escape()
	{
	}

	public void BackGameBtnClick()
	{
		AudioManager._Instance.PlaySound("gameplay_button_click");
		UIPanelManager._Insance.HidePanel("SkipPanel");
	}

	private void KeyBtnClick()
	{
	}

	private void ShopBtnClick()
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

	private void OnDestroy()
	{
	}

	public override void UpdateText()
	{
		 skipText.text = GleyLocalization.Manager.GetText("skip_title");
		_titleText.text = GleyLocalization.Manager.GetText("skip_title");
		_GuideText.text = GleyLocalization.Manager.GetText("skip_guide");
	}

	public override void UpdatePanel()
	{
	}


}

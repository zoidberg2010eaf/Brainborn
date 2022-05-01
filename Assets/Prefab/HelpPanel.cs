using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpPanel : UIPanelBase
{
	
	

	[SerializeField]
	private RectTransform ScaleContent;

	[SerializeField]
	private RectTransform topContent;

	[SerializeField]
	private RectTransform backBtnTran;

	[SerializeField]
	private Button _BackGameBtn;

	[SerializeField]
	private Button _GetKeyBtn;

	[SerializeField]
	private Button _ShopBtn;

	[SerializeField]
	private Text _GuideText;

	[SerializeField]
	private Image[] buttonImgs;

	private Sprite[] btnSprites;

	[SerializeField]
	private RectTransform titleImg;

	[SerializeField]
	private Text titleText;

	[SerializeField]
	private Text shopText;

	

	[SerializeField]
	private Transform tempContent;

	[SerializeField]
	private Transform topTitleContent;

	

	private bool isCantip;

	private int passAd;

	private bool updateShow;

	private bool openAd;

	private Tweener tweener;

	

	[SerializeField]
	private GameObject redMark;

	

	public static int AdJustIndex;

	private void Start()
	{
	}

	public void UpdateRedMark(bool value)
	{
	}

	private IEnumerator UpdateAdState()
	{
		return null;
	}

	private void TipsShowNextClick()
	{
	}

	public override void Escape()
	{
	}

	private void BackGameBtnClick()
	{
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

	private void UpdateAdStatus(bool status)
	{
	}

	public override void UpdateText()
	{
	}

	public override void UpdatePanel()
	{
	}

	private void SingleTipShow()
	{
	}

	private void _003CKeyBtnClick_003Eb__34_0(bool value)
	{
	}
}

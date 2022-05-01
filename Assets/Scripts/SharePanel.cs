using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharePanel : UIPanelBase
{
	
	[SerializeField]
	private Transform tempContent;

	

	[SerializeField]
	private Button _BackGameBtn;

	[SerializeField]
	private Button shareBtn;

	public Text _GuideText;

	[SerializeField]
	private RectTransform titleImg;

	[SerializeField]
	private RectTransform backBtnRect;

	[SerializeField]
	private Text titleText;

	[SerializeField]
	private Text shareText;

	[SerializeField]
	private Transform btnTrans;

	[SerializeField]
	private RectTransform ScaleContent;

	[SerializeField]
	private RectTransform midContent;

	private Tweener tweener;

	private void Start()
	{
	}

	private void FeedBackBtnClick()
	{
	}

	private void RateBtnClick()
	{
	}

	private IEnumerator WaitHide()
	{
		return null;
	}

	public override void Escape()
	{
	}

	private void BackGameBtnClick()
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
	}

	public override void UpdatePanel()
	{
	}
}

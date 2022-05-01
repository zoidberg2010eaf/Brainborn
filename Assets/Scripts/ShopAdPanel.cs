using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopAdPanel : UIPanelBase
{
	
	
	[SerializeField]
	private Transform tempContent;

	

	[SerializeField]
	private Button _BackGameBtn;

	[SerializeField]
	private Button getTipBtn;

	[SerializeField]
	private RectTransform titleImg;

	[SerializeField]
	private RectTransform backBtnRect;

	[SerializeField]
	private Text titleText;

	[SerializeField]
	private Text getTipText;

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

	private IEnumerator UpdateAdState()
	{
		return null;
	}

	private void UpdateAdStatus(bool status)
	{
	}

	private void GetkeyBtnClick()
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

	private void _003CGetkeyBtnClick_003Eb__18_0(bool value)
	{
	}
}

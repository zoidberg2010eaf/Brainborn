using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInPanel : UIPanelBase
{
	

	public static CheckInPanel _Instance;

	[SerializeField]
	private Text title;

	[SerializeField]
	private Text bulbTipText;

	[SerializeField]
	private RectTransform titleImg;

	[SerializeField]
	private GameObject checkInOptionObj;

	[SerializeField]
	private GameObject horContentObj;

	[SerializeField]
	private GameObject redMark;

	[SerializeField]
	private Button _BackBtn;

	

	[SerializeField]
	private RectTransform panelContent;

	[SerializeField]
	private RectTransform topContent;

	[SerializeField]
	private RectTransform viewPort;

	[SerializeField]
	private RectTransform tempContent;

	[SerializeField]
	private ScrollRect ScrollRect;

	

	private Tweener tweener;

	private bool firstShow;

	[SerializeField]
	private Button bulbShopBtn;

	private Vector2 wh;

	private Vector2 vPSize;

	private float maxHeight;

	private void Awake()
	{
	}

	public void UpdateRedMark(bool value)
	{
	}

	private void Start()
	{
	}

	private void BulbShopClick()
	{
	}

	public override void Escape()
	{
	}

	private void BackBtnClick()
	{
	}

	public override void Show()
	{
	}

	private void SpawnOptions()
	{
	}

	private void OptionBtnClick(int index)
	{
	}

	private IEnumerator WaitHide()
	{
		return null;
	}

	public override void Show(object para)
	{
	}

	protected override void UpdateShareRect()
	{
	}

	public Transform GetContentTran()
	{
		return null;
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

	public override void UpdateTips()
	{
	}

	public void UpdateTips(string str)
	{
	}

	private void UpdateCheckIn()
	{
	}

	private void _003CHide_003Eb__34_0()
	{
	}
}

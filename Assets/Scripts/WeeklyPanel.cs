using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WeeklyPanel : UIPanelBase
{
	[SerializeField]
	private Button getBtn;

	[SerializeField]
	private Text guideText;

	[SerializeField]
	private Text getText;

	[SerializeField]
	private RectTransform ScaleContent;

	[SerializeField]
	private GameObject[] marks;

	private Tweener tweener;

	private int curWeekPay;

	private void Start()
	{
	}

	private void FreeGetBtnClick()
	{
	}

	public override void Escape()
	{
	}

	protected override void UpdateShareRect()
	{
	}

	public override void Show()
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

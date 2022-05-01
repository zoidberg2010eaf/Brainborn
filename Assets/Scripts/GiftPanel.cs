using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GiftPanel : UIPanelBase
{
	[SerializeField]
	private Transform tempContent;


	[SerializeField]
	private Button _BackGameBtn;

	[SerializeField]
	private Button shareBtn;

	[SerializeField]
	private RectTransform backBtnRect;

	[SerializeField]
	private Text shareText;

	[SerializeField]
	private Text guideText;

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

	private void RateBtnClick()
	{
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

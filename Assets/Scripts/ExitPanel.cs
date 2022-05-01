using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ExitPanel : UIPanelBase
{
	[SerializeField]
	private Button cancleBtn;

	[SerializeField]
	private Button okBtn;

	[SerializeField]
	private Image[] imgs;

	private Sprite[] sprites;

	[SerializeField]
	private Text _GuideText;

	[SerializeField]
	private Text cancleText;

	[SerializeField]
	private Text okText;

	[SerializeField]
	private RectTransform ScaleContent;

	private Tweener tweener;

	private void Start()
	{
	}

	private void OkBtnClick()
	{
	}

	public override void Escape()
	{
	}

	private void BackGameBtnClick()
	{
	}

	protected override void UpdateShareRect()
	{
	}

	public override void Show()
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

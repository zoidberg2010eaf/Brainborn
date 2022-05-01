using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SpSaleOffPanel : UIPanelBase
{
	

	[SerializeField]
	private RectTransform ScaleContent;

	[SerializeField]
	private RectTransform backBtnTran;

	[SerializeField]
	private Button _BackGameBtn;

	[SerializeField]
	private Button _PayBtn;

	[SerializeField]
	private Text titleText;

	[SerializeField]
	private Text payText;

	[SerializeField]
	private Text priceOldText;

	[SerializeField]
	private Text spOffText;

	

	[SerializeField]
	private Transform tempContent;

	[SerializeField]
	private Transform sp1Tran;

	[SerializeField]
	private Transform sp2Tran;

	[SerializeField]
	private Transform sp3Tran;

	[SerializeField]
	private Transform five;

	[SerializeField]
	private Transform six;

	[SerializeField]
	private Transform ten;

	[SerializeField]
	private Transform noadTran;

	[SerializeField]
	private Transform btnContent;

	public bool updateShow;

	private Tweener tweener;

	[SerializeField]
	private Image oldPriceLineImg;

	[SerializeField]
	private Image titleImg;



	private bool canPay;

	private const string offFormat = "{0}%\n<size=40>OFF</size>";

	private void Start()
	{
	}

	public override void Escape()
	{
	}

	private void BackGameBtnClick()
	{
	}

	private void PayBtnClick()
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

	private void SpecialOfferTimeEnd()
	{
	}

	public override void UpdatePanel()
	{
	}
}

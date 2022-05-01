using UnityEngine;

public class TipsPanel : UIPanelBase
{
	public static TipsPanel _Instance;


	[SerializeField]
	private GameObject keyMessageObj;

	[SerializeField]
	private GameObject keyCellObj;

	[SerializeField]
	private GameObject textMessObj;

	[SerializeField]
	private RectTransform keyRectAnchor;

	[SerializeField]
	private Transform centerPos;

	[SerializeField]
	private Transform startTran;

	[SerializeField]
	private Transform endTrans;

	[SerializeField]
	private Transform keyCellTarget;

	[SerializeField]
	private Transform keyContentTarget;

	[SerializeField]
	private Transform[] startTrans;

	private string message;

	

	private int index;

	private bool add;

	private bool resetIndex;

	private float timmer;

	private float timeCold;

	private void Awake()
	{
	}

	public override void Show()
	{
	}

	private void Update()
	{
	}

	private Transform PopOne()
	{
		return null;
	}

	public override void Escape()
	{
	}

	public override void Show(object para)
	{
	}

	public override void Hide()
	{
	}

	public override void UpdatePanel()
	{
	}

	protected override void UpdateShareRect()
	{
	}

	private void ShowTips()
	{
	}

	
}

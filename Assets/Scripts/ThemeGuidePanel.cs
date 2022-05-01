using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ThemeGuidePanel : UIPanelBase
{
	[SerializeField]
	private Button _GetOkBtn;

	[SerializeField]
	private Text guideText;

	[SerializeField]
	private Text openText;

	[SerializeField]
	private Transform xmasObj;

	[SerializeField]
	private Transform healthObj;

	[SerializeField]
	private Transform game99Obj;

	[SerializeField]
	private Transform fleeOutObj;

	[SerializeField]
	private RectTransform ScaleContent;

	[SerializeField]
	private RectTransform tempCon;

	

	public bool updateShow;

	private Tweener tweener;

	

	private void Start()
	{
	}

	public override void Escape()
	{
	}

	private void LevelBtnClick()
	{
	}

	private void BackGameBtnClick()
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

	private void Update()
	{
	}

	public override void UpdateText()
	{
	}

	public override void UpdatePanel()
	{
	}
}

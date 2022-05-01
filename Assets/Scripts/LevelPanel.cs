using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : UIPanelBase
{
	
	[SerializeField]
	private Button _BackBtn;

	[SerializeField]
	private Scrollbar _scrollBar;

	[SerializeField]
	private Button themeBtn;

	[SerializeField]
	private Image bgImg;

	[SerializeField]
	private ScrollRect _ScrollRect;

	[SerializeField]
	private GameObject _OptionObj;

	[SerializeField]
	private Transform _LevelContent;

	private float pageHeight;

	private float pageWidth;

	private float midWidth;

	private static bool hasPage;

	

	private LevelOption[] levelOptions;

	private Vector2 optionConstraint;

	

	private Transform objParent;

	

	private void Awake()
	{
	}

	private void Start()
	{
		Show();
	}

	public override void Escape()
	{
	}

	private void ThemeBtnClick()
	{
	}


	private void BackBtnClick()
	{
	}

	public override void Show()
	{
		int _unlockLevel = PlayerPrefs.GetInt("UnlockLevel");

		for (int i = 0; i < LevelManager._Instance._MaxLevel; i++)
		{
			
			GameObject _levelItem = GameObject.Instantiate(_OptionObj);
			_levelItem.transform.parent = _LevelContent;
			_levelItem.GetComponent<RectTransform>().localPosition = Vector3.zero;
			_levelItem.GetComponent<RectTransform>().localScale = Vector3.one;

			LevelOption _option = _levelItem.GetComponent<LevelOption>();
			_option._Index = i;
			if (i < _unlockLevel)
				_option.UpdatePanel(LevelState.Unlock);
			else if (i == _unlockLevel)
				_option.UpdatePanel(LevelState.Current);
			else
				_option.UpdatePanel(LevelState.Lock);
			
		}
		_scrollBar.value = 1.0f;
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

	private void SpawnOptionsJson()
	{
	}

	private void OptionBtnClick(int index)
	{
	}

	private void OptionBtnClick(string index)
	{
	}
}

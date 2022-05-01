using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GleyLocalization;

public class LanPanel : UIPanelBase
{
	

	[SerializeField]
	private GameObject lanOpObj;

	[SerializeField]
	private Button _BackGameBtn;

	[SerializeField]
	private RectTransform titleImg;

	[SerializeField]
	private RectTransform viewPort;

	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private Text titleText;

	[SerializeField]
	private Color oriCol;

	[SerializeField]
	private Color selCol;


	[SerializeField]
	private RectTransform panelContent;

	[SerializeField]
	private RectTransform optionContent;

	[SerializeField]
	private RectTransform topContent;

	private Tweener tweener;

	private LanOption[] lanOptions;

	private GameObject temObj;

	private LanOption lanOp;

	public static LanPanel instance;

    private void Awake()
    {
		instance = this;
    }

    private void Start()
	{
		UpdatePanel();
	}

	private IEnumerator WaitHide()
	{
		return null;
	}

	public override void Escape()
	{
	}

	public void BackGameBtnClick()
	{
		UIPanelManager._Insance.HidePanel("LanPanel");
		AudioManager._Instance.PlaySound("gameplay_button_click");
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

	protected override void UpdateShareRect()
	{
	}

	private void OnDestroy()
	{
	}

	public override void UpdateText()
	{
		titleText.text = GleyLocalization.Manager.GetText("lan_Title");
	}

	private void LanOptionBtnClick(int index)
	{
	}

	private void SpawnLanOptions()
	{
	}

	public override void UpdatePanel()
	{
		//Debug.Log("UPDATE PANEL");
		if (lanOptions == null)
        {
			lanOptions = new LanOption[LocalizationManager.Instance.GetLanguageCount()];

			for (int i = 0; i < LocalizationManager.Instance.GetLanguageCount(); i++)
			{

				GameObject _langOption = GameObject.Instantiate(lanOpObj);
				_langOption.transform.parent = optionContent;
				_langOption.transform.localPosition = Vector3.zero;
				_langOption.transform.localScale = Vector3.one;
				lanOptions[i] = _langOption.GetComponent<LanOption>();
				lanOptions[i].UpdateText(LocalizationManager.Instance.GetLanguagueByIndex(i), false, false);
				if (LocalizationManager.Instance.GetCurrentLanguage() == LocalizationManager.Instance.GetLanguagueByIndex(i))
					lanOptions[i].UpdateCol(Color.yellow);
				else
					lanOptions[i].UpdateCol(Color.black);


			}
		}
		else
        {
			for (int i = 0; i < LocalizationManager.Instance.GetLanguageCount(); i++)
			{

				lanOptions[i].UpdateText(LocalizationManager.Instance.GetLanguagueByIndex(i), false, false);
				if (LocalizationManager.Instance.GetCurrentLanguage() == LocalizationManager.Instance.GetLanguagueByIndex(i))
					lanOptions[i].UpdateCol(Color.yellow);
				else
					lanOptions[i].UpdateCol(Color.black);


			}
		}

		UpdateText();
		UIPanelManager._Insance._panelPairs["MenuPanel"].GetComponent<UIPanelBase>().UpdateText();
		FindObjectOfType<LevelLanguageBase>().UpdateText();

	}

}

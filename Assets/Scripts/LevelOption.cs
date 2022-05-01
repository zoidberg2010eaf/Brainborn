using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelOption : OptionBase
{
	public int _Index;

	public string _Value;

	public bool _IsNew;

	[SerializeField]
	private Sprite[] subStateSprites;

	[SerializeField]
	private Image subImg;

	[SerializeField]
	private Image subStateImg;

	[SerializeField]
	private Image newMark;

	[SerializeField]
	private TextMeshProUGUI _GuideText;

	[SerializeField]
	private Color32 unlockCol;

	[SerializeField]
	private Color32 lockCol;

	private LevelState levelState;

	private Button button;

	public Button _Button
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public override void UpdateSize()
	{
	}

	public override void UpdateSize(float width, float height)
	{
	}

	public override void UpdateSize(Vector2 vector)
	{
	}

	public void UpdatePanel(LevelState state)
	{
		newMark.gameObject.SetActive(false);
		levelState = state;
		switch(state)
		{
			case LevelState.Lock:
				_GuideText.text = (_Index + 1).ToString();
				_GuideText.color = lockCol;
				subStateImg.sprite = subStateSprites[2];
				subImg.GetComponent<Image>().enabled = false;
				break;
			case LevelState.Unlock:
				_GuideText.text = (_Index + 1).ToString();
				_GuideText.color = unlockCol;
				subStateImg.sprite = subStateSprites[1];
				subImg.GetComponent<Image>().enabled = true;
				break;
			case LevelState.Current:
				_GuideText.text = (_Index + 1).ToString();
				_GuideText.color = unlockCol;
				subStateImg.sprite = subStateSprites[0];
				subImg.GetComponent<Image>().enabled = true;
				break;
		}
	}

	public void UpdatePanel()
	{
	}

	public void OnClick()
	{
		if(levelState != LevelState.Lock)
		{
			//Debug.Log("Index " + _Index);
			if (_Index >= 50)
				_Index -= 50;
			PlayerPrefs.SetInt("CurrentLevel", _Index);
			if (PlayerPrefs.GetInt("ReviewStatus") == 1)
			{
				UIPanelManager._Insance.ShowPanel("PlayPanel");
			}
			else
			{
				UIPanelManager._Insance.ShowPanel("PlayPanelSimple");
			}
			LevelManager._Instance.LoadLevel();
			MediationManager.SharedInstance.ShowInterstitialAd();
		}
	}
}

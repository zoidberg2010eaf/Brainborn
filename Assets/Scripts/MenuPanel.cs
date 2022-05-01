using DG.Tweening;
using GleyLocalization;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : UIPanelBase
{
	[SerializeField]
	private Button backBtn;

	[SerializeField]
	private Button lanBtn;

	[SerializeField]
	private Button rateBtn;

	[SerializeField]
	private Button feedbackBtn;

	[SerializeField]
	private Button shareBtn;

	[SerializeField]
	private Button musicBtn;

	[SerializeField]
	private Button soundBtn;

	[SerializeField]
	private Button shockBtn;

	[SerializeField]
	private Button termBtn;

	[SerializeField]
	private Button clauseBtn;

	[SerializeField]
	private Button cdkBtn;

	[SerializeField]
	private Button dailyBtn;

	[SerializeField]
	private Button shopBtn;

	[SerializeField]
	private Text rateText;

	[SerializeField]
	private Text feedbackText;

	[SerializeField]
	private Text shareText;

	[SerializeField]
	private Text musicText;

	[SerializeField]
	private Text soundText;

	[SerializeField]
	private Text shockText;

	[SerializeField]
	private Text termText;

	[SerializeField]
	private Text clauseText;

	[SerializeField]
	private Text lanText;

	[SerializeField]
	private Text cdkText;

	[SerializeField]
	private Text dailyText;

	[SerializeField]
	private Text shopText;

	[SerializeField]
	private RectTransform panelContent;

	[SerializeField]
	private RectTransform topContent;

	[SerializeField]
	private RectTransform viewPort;

	[SerializeField]
	private RectTransform tempCon;

	[SerializeField]
	private Animator musicAnimator;

	[SerializeField]
	private Animator soundAnimator;

	[SerializeField]
	private Animator shockAnimator;

	

	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private Image lineImg;

	[SerializeField]
	private Image musicImg;

	[SerializeField]
	private Image soundImg;

	[SerializeField]
	private Image shockImg;

	[SerializeField]
	private GameObject redMark;


	private Tweener tweener;

	public static MenuPanel _Instance;

	private Vector2 vPSize;

	private float maxHeight;

	public Sprite musicOn, musicOff, soundOn, soundOff, shockOn, shockOff;

	private void Awake()
	{
		UpdateText();
		UpdatePanel();
	}

	public void UpdateRedMark(bool value)
	{
	}

	private void Start()
	{
	}

	public void LanBtnClick()
	{
		UIPanelManager._Insance.ShowPanel("LanPanel");
		AudioManager._Instance.PlaySound("gameplay_button_click");
	}

	private void TermBtnClick()
	{
	}

	private void ClauseBtnClick()
	{
	}

	public void MusicBtnClick()
	{
		if (PlayerPrefs.GetInt("Music") == 1)
		{
			musicImg.sprite = musicOff;
			AudioManager._Instance._musicSource.volume = 0.0f;
			PlayerPrefs.SetInt("Music", 0);
		}
		else
		{
			musicImg.sprite = musicOn;
			AudioManager._Instance._musicSource.volume = 1.0f;
			PlayerPrefs.SetInt("Music", 1);
		}
	}

	public void SoundBtnClick()
	{
		if (PlayerPrefs.GetInt("Sound") == 1)
		{
			soundImg.sprite = soundOff;
			AudioManager._Instance._audioSource.volume = 0.0f;
			PlayerPrefs.SetInt("Sound", 0);
		}
		else
		{
			soundImg.sprite = soundOn;
			AudioManager._Instance._audioSource.volume = 1.0f;
			PlayerPrefs.SetInt("Sound", 1);
		}
	}

	public void ShockBtnClick()
	{
		if (PlayerPrefs.GetInt("Shock") == 1)
		{
			shockImg.sprite = shockOff;
			
			PlayerPrefs.SetInt("Shock", 0);
		}
		else
		{
			shockImg.sprite = shockOn;
		
			PlayerPrefs.SetInt("Shock", 1);
		}
	}

	private void DailyBtnClick()
	{
	}

	private void ShopBtnClick()
	{
	}

	private void RateBtnClick()
	{
	}

	private void FeedBackBtnClick()
	{
	}

	private void ShareBtnClick()
	{
	}

	public override void Escape()
	{
	}

	public void BackBtnClick()
	{
		UIPanelManager._Insance.HidePanel("MenuPanel");
		AudioManager._Instance.PlaySound("gameplay_button_click");
	}

	public override void Show()
	{
	}

	public override void Show(object para)
	{
	}

	protected override void UpdateShareRect()
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
		lanText.text = LocalizationManager.Instance.GetCurrentLanguage().ToString(); 
		musicText.text = GleyLocalization.Manager.GetText("menu_music");
		soundText.text = GleyLocalization.Manager.GetText("menu_sound");
		shockText.text = GleyLocalization.Manager.GetText("menu_shock");
		dailyText.text = GleyLocalization.Manager.GetText("menu_daily");
		shopText.text = GleyLocalization.Manager.GetText("menu_shop");
		rateText.text = GleyLocalization.Manager.GetText("menu_rate");
		feedbackText.text = GleyLocalization.Manager.GetText("menu_feedback");
		shareText.text = GleyLocalization.Manager.GetText("menu_share");
		termText.text = GleyLocalization.Manager.GetText("menu_term");
		clauseText.text = GleyLocalization.Manager.GetText("menu_clause");
		cdkText.text = GleyLocalization.Manager.GetText("cdk_menu");
	}

	public override void UpdatePanel()
	{
		if(PlayerPrefs.GetInt("Music") == 1)
        {
			musicImg.sprite = musicOn;
		
        }
		else
        {
			musicImg.sprite = musicOff;
        }

		if(PlayerPrefs.GetInt("Sound") == 1)
        {
			soundImg.sprite = soundOn;
        }
		else
        {
			soundImg.sprite = soundOff;
        }

		if (PlayerPrefs.GetInt("Shock") == 1)
		{
			shockImg.sprite = shockOn;
		}
		else
		{
			shockImg.sprite = shockOff;
		}
	}

	public void UpdateSetAnimator()
	{

	}

	public void Rate()
    {
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.xilbuutt.brainchallenge");
	}	
	
	public void FeedBack()
    {
		string email = "appsdevh@gmail.com";
		string subject = "";
		string body = "";

		Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
	}

	public void Privacy()

    {
		Application.OpenURL("http://zmazi.com/iqbrain/privacy.html");
	}

	
}

using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanelOther : UIPanelBase
{
	

	[SerializeField]
	private Button noThnkxBtn;

	[SerializeField]
	private Button getMoreBtn;

	[SerializeField]
	private Button _GetKeyBtn;

	public Text _WinGuideText;

	public Text nextText;

	public Text titleText;

	public Text rankLvText;

	public Transform animatedCoinsParent;
	public Text cointsTextTop, coinsTextBottom;
	public int coinsPerLevel;

	[SerializeField]
	private Image manImg;


	[SerializeField]
	private RectTransform titleImg;


	[SerializeField]
	private Transform tempTrans;

	[SerializeField]
	private Transform btnTrans;

	[SerializeField]
	private Transform ranTran;

	[SerializeField]
	private Image[] buttonImgs;

	private Sprite[] btnSprites;

	[SerializeField]
	private RectTransform conTran;

	[SerializeField]
	private RectTransform sliderPointer;

	[SerializeField]
	private GameObject doneScreen;


	[SerializeField]
	private RectTransform clapTran;

	[SerializeField]
	private RectTransform clapTarget;

	private Tweener ConTweener;

	private Tweener ClapTweener;

	private int index;

	private static bool isExit;

	

	private float oriAnPosY;

	private float curBottom;

	private float multiplier;


	private void Start()
	{
		int lvlNum = LevelManager._Instance.currentLevel;
		Debug.Log("currentLevel" + LevelManager._Instance.currentLevel);
		int robuxTOEarn= PlayerPrefs.GetInt("robuxToEarn");
		float num = 7 / ((float)lvlNum * (float)lvlNum);
		Debug.Log("num:" + num);
		float coinsPerLevel1 = (float)(robuxTOEarn / 100) * num;
		Debug.Log("coinsPerLevel1:" + coinsPerLevel1);
		coinsPerLevel = (int)(coinsPerLevel1);

		if (coinsPerLevel < 1)
        {
			coinsPerLevel = 1;
        }
		Debug.Log("coinsPerLevel: " + coinsPerLevel);
		AudioManager._Instance.PlaySound("gameplay_win1");
		UpdatePanel();
		//cointsTextTop.text = ""+PlayerPrefs.GetInt("Totalcoins");
		cointsTextTop.text = ""+UIPanelManager._Insance.totalGems;
		coinsTextBottom.text = "+" + coinsPerLevel;
		Invoke("EnablenoThnkxBtn", 1f);
	}

	public override void Escape()
	{

	}
	void EnablenoThnkxBtn()
    {
		noThnkxBtn.gameObject.SetActive(true);
    }
	public void NextBtnClick()
	{
		//int totalCoins = PlayerPrefs.GetInt("Totalcoins") + coinsPerLevel;
		//PlayerPrefs.SetInt("Totalcoins", totalCoins);

		//ADD POINTS
		//RewardManager.SharedInstance.AddPoints(coinsPerLevel);
		//UIPanelManager._Insance.totalGems += coinsPerLevel;
		StartCoroutine(AnimateCoins(coinsPerLevel));
		//LoadNextLevel();

		
	}
	void LoadNextLevel()
    {
		RewardManager.SharedInstance.GetUserData();
		LevelManager._Instance.currentLevel++;
		if (LevelManager._Instance.currentLevel >= 50)
			LevelManager._Instance.currentLevel -= 50;
		PlayerPrefs.SetInt("CurrentLevel", LevelManager._Instance.currentLevel - 1);
		UIPanelManager._Insance.ShowPanel("PlayPanel");
		LevelManager._Instance.LoadLevel();
	}
	private void KeyBtnClick()
	{
	}

	private IEnumerator UpdateAdState()
	{
		return null;
	}

	private void UpdateAdStatus(bool status)
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


	public override void UpdateText()
	{
		_WinGuideText.text = GleyLocalization.Manager.GetText("WinGuide" + LevelManager._Instance.currentLevel);
		titleText.text = GleyLocalization.Manager.GetText("WinTitle");
		nextText.text = GleyLocalization.Manager.GetText("WinNext");
		rankLvText.text = "lvl." + LevelManager._Instance.currentLevel;
	}

	public override void UpdatePanel()
	{
		UpdateText();
		if(LevelManager._Instance.currentLevel >= LevelManager._Instance._unlockLevel)
		{
			LevelManager._Instance._unlockLevel++;
			PlayerPrefs.SetInt("UnlockLevel", LevelManager._Instance._unlockLevel -1);
		}
	}


    //public void FreeBtnClick()
    //{
    //	//AdmobAd2.instance.ShowRewardedAd();
    //}

	public void GetMoreBtnClick()
    {
		getMoreBtn.interactable = false;
		sliderPointer.GetComponent<Animator>().speed = 4f;
		StartCoroutine(SliderStopChecker());
	}
    IEnumerator SliderStopChecker()
    {
		int randomNum = UnityEngine.Random.Range(0, 100);
		float sliderStopperValue = 0f;
		if (randomNum < 2)
		{
			sliderStopperValue = 5;
		}
		else if (randomNum >= 2 && randomNum < 5)
		{
			sliderStopperValue = 3;
		}
		else if (randomNum >= 5 && randomNum < 15)
		{
			sliderStopperValue = 2;
		}
		else
		{
			sliderStopperValue = 1.5f;
		}

		yield return new WaitForSeconds(4f);

		yield return new WaitUntil(() => (sliderPointer.GetComponent<SliderValueSetter>().GetSliderValue() == sliderStopperValue));
		sliderPointer.GetComponent<Animator>().enabled = false;
		multiplier = sliderStopperValue;
		FreeBtnClick();


	}
    public void FreeBtnClick()
    {
		
		 
		Debug.Log("multiplier value: " + multiplier);
		if(MediationManager.SharedInstance.ShowRewardedVideo(RewardUser)){
            Debug.Log("Ad Shown");
        }
        else{
            Debug.Log("No Ads Available");
        }
		
    }
	void RewardUser(bool isRewarded)
	{
		if (isRewarded)
		{
			//give reward to user
			int totalCoinsPerLevel = (int)(coinsPerLevel * multiplier);
			Debug.Log("totalCoins: " + totalCoinsPerLevel);
			coinsTextBottom.text = "+" + totalCoinsPerLevel;
			
			Debug.Log("User Rewarded");

			
			StartCoroutine(AnimateCoins(totalCoinsPerLevel));
		}
		else
		{
			Debug.Log("Not Rewarded");
		}
	}
	IEnumerator AnimateCoins(int totalCoinsPerLevel)
    {
		doneScreen.SetActive(true);
        int c = UIPanelManager._Insance.totalGems;
        animatedCoinsParent.gameObject.SetActive(true);
		//to complete coins animation
		yield return new WaitForSeconds(1.75f);

		int coinToAdd = totalCoinsPerLevel / 3;
		int num = 0;
		int a = 0;
        while (num!=3)
        {
			a+=coinToAdd;
			cointsTextTop.text = "" + (c+a);
			cointsTextTop.gameObject.GetComponent<DOTweenAnimation>().DORestart();
			num++;
			yield return new WaitForSeconds(0.1f);


		}

		UIPanelManager._Insance.totalGems += totalCoinsPerLevel;
		
		cointsTextTop.text = "" + UIPanelManager._Insance.totalGems;

		//ADD POINTS
		RewardManager.SharedInstance.AddPoints(totalCoinsPerLevel);
		yield return new WaitForSeconds(0.7f);
		animatedCoinsParent.gameObject.SetActive(false);
		LoadNextLevel();
	}
}
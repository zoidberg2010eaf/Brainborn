using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : UIPanelBase
{
	public static ShopPanel _Instance;
	

	[SerializeField]
	private Button restoreBtn;

	[SerializeField]
	private Button backBtn;

	[SerializeField]
	private RectTransform titleImg;

	[SerializeField]
	private RectTransform restoreObj;

	[SerializeField]
	private RectTransform resOriPos;

	[SerializeField]
	private GameObject noAdAvailableTxt;

	[SerializeField]
	private Text titleText;

	[SerializeField]
	private Text tipText;

	[SerializeField]
	private Text restoreText;


	[SerializeField]
	private Text freeText1;


	[SerializeField]
	private Text freeText2;

	[SerializeField]
	private Text removeAdsText;

	[SerializeField]
	private Image reslineImg;

	[SerializeField]
	private RectTransform panelContent;

	[SerializeField]
	private RectTransform topContent;

	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private Transform tempContent;

	[SerializeField]
	private Transform restoreCon;

	



	public static bool updateShow;

	private Tweener tweener;

	public int panelIndex;

	private float contentOff;

	private int saleOpenCount;

	

	public int SaleOpenCount
	{
		get
		{
			return 0;
		}
		private set
		{
		}
	}

	private void Awake()
	{
		UpdateText();
		UpdateTips();
	}

	private void Update()
	{
		tipText.text = GameManager._Instance._Tips.ToString();
	}

	public void DailyPayCall()
	{
	}

    public void SpSaleOffCall(int type, bool show = false)
	{
	}

	//public void RestoreBtnClick()
	//{
	//	IAPManager.instance.RestorePurchases();
	//}

	//public void BuyTipPack(int _index)
 //   {
	//	IAPManager.instance.BuyProductConsume(_index);
 //   }	
	
	//public void RemoveAds()
 //   {
	//	IAPManager.instance.BuyProductNonConsume(0);
 //   }		
	
	public void BackBtnClick()
	{
		UIPanelManager._Insance.HidePanel("ShopPanel");
	}

	public Transform GetContentTran()
	{
		return null;
	}

	public override void Show()
	{
	}

	public void FreeBtnClick()
	{
		//AdmobAd2.instance.ShowRewardedAd();
		if (MediationManager.SharedInstance.ShowRewardedVideo(RewardUser))
		{
			Debug.Log("Ad Shown");
		}
		else
		{
			noAdAvailableTxt.SetActive(true);
			Invoke("DisablenoAdAvailable", 1.5f);
			Debug.Log("No Ads Available");
		}
	}
	void DisablenoAdAvailable()
    {
		noAdAvailableTxt.SetActive(false);
	}
	void RewardUser(bool isRewarded)
	{
		if (isRewarded)
		{
			GameManager._Instance._Tips++;
			PlayerPrefs.SetInt("Tips", GameManager._Instance._Tips);
			Debug.Log("User Rewarded");
		}
		else
		{
			Debug.Log("Not Rewarded");
		}
	}


	public override void UpdateText()
	{
		titleText.text = GleyLocalization.Manager.GetText("menu_shop");
		restoreText.text = GleyLocalization.Manager.GetText("shop_restore");
		freeText1.text  = GleyLocalization.Manager.GetText("shop_free");
		freeText2.text = GleyLocalization.Manager.GetText("shop_free");
		removeAdsText.text = GleyLocalization.Manager.GetText("noAds");
	}

	

	
}

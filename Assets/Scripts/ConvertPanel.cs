using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvertPanel : UIPanelBase
{
	public static ConvertPanel _Instance;
	public Sprite male, female;
	[SerializeField]
	private Text userName,coinsTxt, robuxToEarn, coinsDivideTotalRobux;

	[SerializeField]
	private Image userImage;

	[SerializeField]
	private Slider coinsFiller;

	[SerializeField]
	private InputField userNameUpdate;

	[SerializeField]
	private Button redeemButton;


	int totalAimRobux,totalCoins;

	private void Awake()
	{
		//totalCoins = PlayerPrefs.GetInt("Totalcoins");
		totalCoins = UIPanelManager._Insance.totalGems;
		coinsTxt.text = "BALANCE: "+ totalCoins;
		totalAimRobux = PlayerPrefs.GetInt("robuxToEarn");
		robuxToEarn.text = "+"+totalAimRobux;
		coinsFiller.maxValue = totalAimRobux;
		coinsFiller.minValue = 0;
		coinsFiller.value = totalCoins;
		userName.text = PlayerPrefs.GetString("userName");
		if (PlayerPrefs.GetString("Gender") == "Female")
		{
			userImage.sprite = female;
		}
		else
		{
			userImage.sprite = male;
		}

	}

	private void Update()
	{
		totalCoins = RewardManager.SharedInstance.totalGems;
		coinsTxt.text = "BALANCE: " + totalCoins;
		coinsFiller.value = totalCoins;
		
		coinsDivideTotalRobux.text = UIPanelManager._Insance.totalGems.ToString() + " / " + totalAimRobux;

	}
	public void UpdateUserName()
    {
		PlayerPrefs.SetString("userName", userNameUpdate.text);
		userName.text= PlayerPrefs.GetString("userName");
	}
	public void MenuBtnClick()
	{
		UIPanelManager._Insance.HidePanel("ConvertPanel");
		UIPanelManager._Insance.ShowPanel("MenuPanel");
		AudioManager._Instance.PlaySound("gameplay_button_click");
	}
	public void BackBtnClick()
	{

		UIPanelManager._Insance.HidePanel("ConvertPanel");
		AudioManager._Instance.PlaySound("gameplay_button_click");
	}


}

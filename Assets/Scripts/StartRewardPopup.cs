using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartRewardPopup : MonoBehaviour
{
    public Text coinsText;
	public GameObject doneScreen, animatedCoinsParent;
	public Text cointsTextTop;

	// Start is called before the first frame update
	void Start()
    {
        coinsText.text= UIPanelManager._Insance.totalGems.ToString()+" COINS";
	}

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClaimBtnClick()
    {
		StartCoroutine(AnimateCoins());
    }
	IEnumerator AnimateCoins()
	{
		doneScreen.SetActive(true);
		int c = 0;
		animatedCoinsParent.gameObject.SetActive(true);
		//to complete coins animation
		yield return new WaitForSeconds(1.1f);

		int coinToAdd = UIPanelManager._Insance.totalGems / 3;
		int num = 0;
		int a = 0;
		while (num != 3)
		{
			a += coinToAdd;
			cointsTextTop.text = "" + (c + a);
			cointsTextTop.gameObject.GetComponent<DOTweenAnimation>().DORestart();
			num++;
			yield return new WaitForSeconds(0.1f);


		}


		cointsTextTop.text = "" + UIPanelManager._Insance.totalGems;

		yield return new WaitForSeconds(0.5f);
		animatedCoinsParent.gameObject.SetActive(false);
		PlayerPrefs.SetInt("is1stReward", 1);
		gameObject.SetActive(false);
	}
}

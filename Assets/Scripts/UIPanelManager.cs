using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class UIPanelManager : MonoBehaviour
{
	public static UIPanelManager _Insance;

	public RectTransform _PanelParent;

	public Dictionary<string, GameObject> _panelPairs;

	private Stack<string> uiPanelStack;

	public string _currentPanel;

	public GameObject _currentPanelObject, _lastPanelObject;

	public GameObject _resultTrue, _resultFalse;
	public GameObject lvlCmpParticles;

	public string _keyPanel;

	public static int TextureWidth;

	public static int TextureHeight;

	public float _ScreenWidth;

	public float _ScreenHeight;

	public float _CanvasWidth;

	public float _CanvasHeight;

	public float _ScreenExtent;

	public int totalGems;

	public float canvaScale;
	GameObject lvlParticle;
	

	private const string panelFolder = "Panel/";

	private string resName;

	private float animationSpeed;

	string playPanelName;

	private void Awake()
	{
		_Insance = this;
		if(PlayerPrefs.GetInt("ReviewStatus") ==1){
			playPanelName = "PlayPanel";
		}
        else
        {
			playPanelName = "PlayPanelSimple";
		}
		//get user coins
		RewardManager.SharedInstance.GetUserData();

		Application.targetFrameRate = 60;
		_panelPairs = new Dictionary<string, GameObject>();
		animationSpeed = 500.0f;
		ShowPanel("LevelPanel");
	}

	

	private void InitCanvasSize()
	{
	}

	private void Update()
	{
		totalGems= RewardManager.SharedInstance.totalGems;
	}

	public string PopStackPanel()
	{
		return "";
	}

	public void SetPanelNext(string panelName)
	{
	}

	public void SetPanelLast(string panelName)
	{
	}

	public void ShowPanelNext()
	{
	}

	public void ShowPanelLast()
	{
	}

	public Transform GetShowKeyCellTran()
	{
		return null;
	}

	public void ShowPanel(string panelName)
	{
		
		if (_currentPanelObject != null)
		{
			
			

			switch (panelName)
			{
				case "LevelPanel":

					if (_currentPanelObject.GetComponent<UIPanelBase>()._PanelName == playPanelName)
					{
						HideUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, true, Tween.TweenStyle.EaseOut, null);
						_lastPanelObject = _currentPanelObject;
						_panelPairs.Remove(panelName);
						Destroy(_lastPanelObject, 0.5f);
						LevelManager._Instance.HideLevel();
						
					}
						

					break;
				case "PlayPanel":
				case "PlayPanelSimple":
					if (_currentPanelObject.GetComponent<UIPanelBase>()._PanelName == "LevelPanel")
					{
						HideUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, true, Tween.TweenStyle.EaseOut, null);
						_lastPanelObject = _currentPanelObject;
						_panelPairs.Remove(panelName);
						Destroy(_lastPanelObject, 0.5f);
					}

					if (_currentPanelObject.GetComponent<UIPanelBase>()._PanelName == playPanelName)
					{
						HideUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, true, Tween.TweenStyle.EaseOut, null);
						_lastPanelObject = _currentPanelObject;
						_panelPairs.Remove(panelName);
						Destroy(_lastPanelObject, 0.5f);

					}

					if (_currentPanelObject.GetComponent<UIPanelBase>()._PanelName == "WinPanel" 
						|| _currentPanelObject.GetComponent<UIPanelBase>()._PanelName == "SkipPanel"
						|| _currentPanelObject.GetComponent<UIPanelBase>()._PanelName == "WinPanelSimple")
					{
						HideUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, true, Tween.TweenStyle.EaseOut, null);
						_lastPanelObject = _currentPanelObject;
						Destroy(_panelPairs[playPanelName]);
						_panelPairs.Remove(panelName);
						Destroy(_lastPanelObject, 0.5f);
						
					}


					break;

				case "GuidePanel" :
					{

					}
					break;

				case "WinPanel":
				case "WinPanelSimple":
					{
						
					}
					break;
				case "MenuPanel":
                    {

                    }
					break;
			}

		}

		GameObject _panelObject = Instantiate(Resources.Load("panel/" + panelName)) as GameObject;
		_panelObject.transform.parent = _PanelParent.transform;
		_panelObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
		_panelObject.GetComponent<RectTransform>().localScale = Vector3.one;
		_panelObject.GetComponent<RectTransform>().sizeDelta = Vector3.zero;
		_currentPanelObject = _panelObject;
		if(_lastPanelObject != null)
		 _currentPanelObject.GetComponent<UIPanelBase>()._LastPanel = _lastPanelObject.GetComponent<UIPanelBase>()._PanelName;
		_currentPanelObject.GetComponent<UIPanelBase>()._PanelName = panelName;

		switch(panelName)
		{
			case "LevelPanel":
				_panelPairs.Add(panelName, _currentPanelObject);
				ShowUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, true, Tween.TweenStyle.EaseOut, null);
				break;
			case "PlayPanel":
			case "PlayPanelSimple":
				_panelPairs.Add(panelName, _currentPanelObject);
				ShowUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), false, true, Tween.TweenStyle.EaseOut, null);
				break;
			case "WinPanel":
			case "WinPanelSimple":
				ShowUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, true, Tween.TweenStyle.EaseOut, null);
				break;
			case "GuidePanel":
				ShowUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, true, Tween.TweenStyle.EaseOut, null);
				break;
			case "MenuPanel":
				_panelPairs.Add(panelName, _currentPanelObject);
				ShowUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, true, Tween.TweenStyle.EaseOut, null);
				break;
			case "LanPanel":
				ShowUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, true, Tween.TweenStyle.EaseOut, null);
				break;
			case "ShopPanel":
				ShowUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, true, Tween.TweenStyle.EaseOut, null);
				break;
			case "SkipPanel":
				ShowUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, true, Tween.TweenStyle.EaseOut, null);
				break;
		}

		
		
	}

	public void ShowPanel(string panelName, [Optional] object para)
	{
	}

	public void HidePanel(string panelName)
	{
		

		switch (panelName)
		{
			case "LevelPanel":
				HideUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, true, Tween.TweenStyle.EaseOut, null);
				break;

			case "PlayPanel":
			case "PlayPanelSimple":
				HideUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, true, Tween.TweenStyle.EaseOut, null);
				break;

			case "GuidePanel":
				{
					HideUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, true, Tween.TweenStyle.EaseOut, null);
					_lastPanelObject = _currentPanelObject;
					Destroy(_lastPanelObject, 0.65f);
					_currentPanelObject = _panelPairs[playPanelName];
					if (_lastPanelObject != null && _currentPanelObject != null)
						_currentPanelObject.GetComponent<UIPanelBase>()._LastPanel = _lastPanelObject.GetComponent<UIPanelBase>()._PanelName;
					_currentPanelObject.GetComponent<UIPanelBase>()._PanelName = playPanelName;
				}
				break;
			case "MenuPanel":
                {
					HideUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, false, Tween.TweenStyle.EaseOut, null);
					_lastPanelObject = _currentPanelObject;
					_currentPanelObject = _panelPairs[playPanelName];
					_panelPairs.Remove("MenuPanel");
					Destroy(_lastPanelObject, 0.65f);
				}
				break;
			case "LanPanel":
				{
					HideUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, false, Tween.TweenStyle.EaseOut, null);
					_lastPanelObject = _currentPanelObject;
					_currentPanelObject = _panelPairs["MenuPanel"];
					Destroy(_lastPanelObject, 0.65f);
				}
				break;
			case "ShopPanel":
				{
					HideUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, false, Tween.TweenStyle.EaseOut, null);
					_lastPanelObject = _currentPanelObject;
					_currentPanelObject = _panelPairs[playPanelName];
					Destroy(_lastPanelObject, 0.65f);
				}
				break;
			case "ConvertPanel":
				{
					HideUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, false, Tween.TweenStyle.EaseOut, null);
					_lastPanelObject = _currentPanelObject;
					_currentPanelObject = _panelPairs[playPanelName];
					Destroy(_lastPanelObject, 0.65f);

				}
				break;
			case "SkipPanel":
				{
					HideUIScreen(_currentPanelObject.GetComponent<UIPanelBase>(), true, true, Tween.TweenStyle.EaseOut, null);
					_lastPanelObject = _currentPanelObject;
					Destroy(_lastPanelObject, 0.65f);
					_currentPanelObject = _panelPairs[playPanelName];
					if (_lastPanelObject != null && _currentPanelObject != null)
						_currentPanelObject.GetComponent<UIPanelBase>()._LastPanel = _lastPanelObject.GetComponent<UIPanelBase>()._PanelName;
					_currentPanelObject.GetComponent<UIPanelBase>()._PanelName = playPanelName;
				}
				break;
		}

	}

	public void ShowWrong(Vector2 point)
	{
		AudioManager._Instance.PlaySound("wrong_choose");
		GameObject _wrong = GameObject.Instantiate(_resultFalse);
		_wrong.GetComponent<RectTransform>().parent = _PanelParent.transform;
		_wrong.GetComponent<RectTransform>().localPosition = new Vector3(point.x,point.y,0.0f);
		_wrong.GetComponent<RectTransform>().localScale = Vector3.zero;

		Tween _tweenX = Tween.ScaleX(_wrong.transform, Tween.TweenStyle.EaseIn, 0.0f, 1.25f, 350, Tween.LoopType.None);
		Tween _tweenY = Tween.ScaleY(_wrong.transform, Tween.TweenStyle.EaseIn, 0.0f, 1.25f, 350, Tween.LoopType.None);
		_tweenX.SetUseRectTransform(true);
		_tweenY.SetUseRectTransform(true);
		_tweenX.SetFinishCallback((tweenedObject, bundleObjects) => {

			Tween _tweenX1 = Tween.ScaleX(_wrong.transform, Tween.TweenStyle.EaseIn, 1.25f, 0.0f, 350, Tween.LoopType.None);
			_tweenX1.SetUseRectTransform(true);
		});

		_tweenY.SetFinishCallback((tweenedObject, bundleObjects) => {

			Tween _tweenY1 = Tween.ScaleY(_wrong.transform, Tween.TweenStyle.EaseIn, 1.25f, 0.0f, 350, Tween.LoopType.None);
			_tweenY1.SetUseRectTransform(true);
			Destroy(_wrong.gameObject, 0.75f);
		});

	}

	public void ShowRight(Vector2 point)
	{
		AudioManager._Instance.PlaySound("correct_choose");
		GameObject _right = GameObject.Instantiate(_resultTrue);
		_right.GetComponent<RectTransform>().parent = _PanelParent.transform;
		_right.GetComponent<RectTransform>().localPosition = new Vector3(point.x, point.y, 0.0f);
		_right.GetComponent<RectTransform>().localScale = Vector3.zero;

		Tween _tweenX = Tween.ScaleX(_right.transform, Tween.TweenStyle.EaseIn, 0.0f, 1.25f, 500, Tween.LoopType.None);
		Tween _tweenY = Tween.ScaleY(_right.transform, Tween.TweenStyle.EaseIn, 0.0f, 1.25f, 500, Tween.LoopType.None);
		_tweenX.SetUseRectTransform(true);
		_tweenY.SetUseRectTransform(true);

		_tweenX.SetFinishCallback((tweenedObject, bundleObjects) => {

			StartCoroutine(ShowWinPanelIE());
			Destroy(_right, 0.5f);
		});

	}

	IEnumerator ShowWinPanelIE()
	{
		lvlParticle= Instantiate(lvlCmpParticles);
		yield return new WaitForSeconds(2f);
		Destroy(lvlParticle);

		if (PlayerPrefs.GetInt("ReviewStatus") == 1)
		{
			if (LevelManager._Instance.currentLevel >= LevelManager._Instance._unlockLevel)
			{
				ShowPanel("WinPanel");
			}
			else
			{
				LoadNextLevel();
			}
		}
		else
		{
			ShowPanel("WinPanelSimple");
		}
		
	}
	void LoadNextLevel()
    {
		RewardManager.SharedInstance.GetUserData();
		LevelManager._Instance.currentLevel++;
		if (LevelManager._Instance.currentLevel >= 50)
			LevelManager._Instance.currentLevel -= 50;
		PlayerPrefs.SetInt("CurrentLevel", LevelManager._Instance.currentLevel - 1);
		UIPanelManager._Insance.ShowPanel(playPanelName);
		LevelManager._Instance.LoadLevel();
	}
	public void Right()
	{

	}

	private void TransitionUIScreen(UIPanelBase uiScreen, float fromX, float toX, bool animate, Tween.TweenStyle style, System.Action onTweenFinished)
	{
		uiScreen._RectTransform.localPosition = new Vector2(fromX, uiScreen._RectTransform.localPosition.y);
		if (animate)
		{
			Tween tween = Tween.PositionX(uiScreen._RectTransform, style, fromX , toX, animationSpeed);
			//Debug.Log("From " + fromX + "  to " + toX );
			tween.SetUseRectTransform(true);
			if (onTweenFinished != null)
			{
				tween.SetFinishCallback((tweenedObject, bundleObjects) => { onTweenFinished(); });
			}
		}
		else
		{
			uiScreen._RectTransform.anchoredPosition = new Vector2(toX, uiScreen._RectTransform.anchoredPosition.y);
		}
		
		
	}

	private void HideUIScreen(UIPanelBase uiScreen, bool animate, bool fromBack, Tween.TweenStyle style, System.Action onTweenFinished)
	{
		if (uiScreen == null)
		{
			return;
		}
		float direction = (fromBack ? 1f : -1f);
		float fromX = 0;
		float toX = uiScreen._RectTransform.rect.width * direction;
		float fromWorldX = 0;
		TransitionUIScreen(uiScreen, fromX, toX, animate, style, onTweenFinished);
	}

	private void ShowUIScreen(UIPanelBase uiScreen, bool animate, bool fromLeft, Tween.TweenStyle style, System.Action onTweenFinished)
	{
		if (uiScreen == null)
		{
			return;
		}
		
		float direction = (fromLeft ? -1f : 1f);
		float fromX = uiScreen._RectTransform.rect.width * direction;
		float toX = 0;
		//float fromWorldX = Utilities.WorldWidth * direction;
		float toWorldX = 0;
		//isAnimating = animate;
		//Debug.Log("From " + fromX + "  to " + toX);
		TransitionUIScreen(uiScreen, fromX, toX, animate, style, () =>
		{
			//isAnimating = false;
			if (onTweenFinished != null)
			{
				onTweenFinished();
			}
		});
	}


	

}

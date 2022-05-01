using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	

	public static LevelManager _Instance;

	[SerializeField]
	private bool Sortversion;

	private bool mark;

	[SerializeField]
	private List<GameObject> allLevelObjs;

	private Dictionary<string, GameObject> allLevelPairs;

	[SerializeField]
	private GameObject endLevelObj;

	[SerializeField]
	private List<GameObject> trailLevels;

	[SerializeField]
	private List<GameObject> levelObjs;

	public List<GameObject> sortLevelIndex;

	[SerializeField]
	private List<GameObject> gyroLevelObjs;

	[SerializeField]
	private List<GameObject> lowResolutionObjs;

	[SerializeField]
	private List<GameObject> spLevelObjs;

	[SerializeField]
	private List<GameObject> notMultiTouchObjs;

	[SerializeField]
	private List<GameObject> lowCanotMultiTouchObjs;

	[SerializeField]
	public List<GameObject> xmasObjs;

	private Dictionary<string, int> _xmasAllLevelIndex;

	[SerializeField]
	public List<GameObject> healthObjs;

	private Dictionary<string, int> _healthAllLevelIndex;

	[SerializeField]
	public List<GameObject> game99Objs;

	private Dictionary<string, int> _game99AllLevelIndex;

	[SerializeField]
	public List<GameObject> fleeOutObjs;

	private Dictionary<string, int> _fleeOutAllLevelIndex;

	private bool beGyrp;

	private Dictionary<string, GameObject> _trailGames;

	private Dictionary<string, int> _allLevelIndex;

	public Dictionary<string, int> _TrailLvIndexPairs;

	public Dictionary<string, int> _TrailIndexPairs;

	private Dictionary<int, string> _TrailNamePairs;

	public int _MaxLevel;

	public int _unlockLevel;

	public int _XmasMaxLevel;

	public int _HealthMaxLevel;

	public int _Game99MaxLevel;

	public int _FleeOutMaxLevel;

	private GameObject levelObj;



	public Transform levelParent;

	public int currentLevel;

	public int currentTips;

	public string currentLevelName;



	public bool IsTrailLevel;

	private Dictionary<string, string> SpLevelDic;

	

	private int lvCount;

	private void Awake()
	{
		_Instance = this;
		_unlockLevel = PlayerPrefs.GetInt("UnlockLevel") + 1;
		//GleyLocalization.Manager.SetCurrentLanguage(SupportedLanguages.Vietnamese);
	}


	private void SpLevelReplace()
	{
	}

	private void InitLevel()
	{

	}

	public string GetTrailShowIndex(string trailName)
	{
		return "";
	}

	private void AddLevelIndex(string name, int index)
	{
	}

	private void InsertLevelObj(int index, GameObject obj)
	{
	}

	private void Start()
	{
	}

	public void InitTrailLevel()
	{
	}

	public void SetLevelParent(Transform trans)
	{
	}

	public void LevelPause()
	{
	}

	
	public void LoadLevel()
	{
		if (levelObj != null)
			HideLevel();
		currentLevel = PlayerPrefs.GetInt("CurrentLevel") + 1;
		levelObj = Instantiate(Resources.Load("Levels/" + currentLevel)) as GameObject;
		//levelParent = UIPanelManager._Insance._PanelParent;
		levelObj.transform.parent = levelParent.transform;
		levelObj.GetComponent<RectTransform>().localPosition = Vector3.zero;
		levelObj.GetComponent<RectTransform>().localScale = Vector3.one;
		levelObj.GetComponent<RectTransform>().sizeDelta = Vector3.zero;
		levelObj.GetComponent<LevelLanguageBase>().Init();
	}

	public void UnLockLevel()
	{
	}

	public void RestartLevel(bool isRepairRect = false)
	{
	}

	public void LoadLastLevel()
	{
	}


	public void UpdateCurTips(int curTip)
	{
	}

	
	public void NorLvAdJust()
	{
	}

	public void LevelAdJust(bool isSkip = false)
	{
	}

	public bool CheckLvLimit(int limit)
	{
		return false;
	}

	public void HideLevel()
	{
		Destroy(levelObj);
	}

}

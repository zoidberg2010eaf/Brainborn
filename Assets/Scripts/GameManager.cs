using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	
	public static GameManager _Instance;

	private int xmasCurrentLevel;

	private int healthCurrentLevel;

	private int game99CurrentLevel;

	private int fleeOutCurrentLevel;

	private int currentLevelType;

	public List<int> _XmasUnLockLvs;

	public List<int> _XmasSkipLvs;

	public List<int> _HealthUnLockLvs;

	public List<int> _HealthSkipLvs;

	public List<int> _Game99UnLockLvs;

	public List<int> _Game99SkipLvs;

	public List<int> _FleeOutUnLockLvs;

	public List<int> _FleeOutSkipLvs;

	public int _TallestLv;

	public int _XmasTallestLv;

	public int _HealthTallestLv;

	public int _Game99TallestLv;

	public int _FleeOutTallestLv;

	private int _003C_TallestCompletedLv_003Ek__BackingField;

	public int _Tips;

	public List<int> _UnLockLevels;

	public List<int> _SkipLevels;

	private Dictionary<string, int> _TrailLevelStatus;

	private Dictionary<string, int> _LVTipsStatus;

	private int currentLevel;

	[SerializeField]
	private AnimationCurve numAddCurve;

	public static bool IsNewUser;

	private int unlock;

	private int tempTall;


	private List<string> newThemes;


	private bool openTemp;

	public bool isLevelClear;

	public int _CurrentLevel
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int _XmasCurrentLevel
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int _HealthCurrentLevel
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int _Game99CurrentLevel
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int _FleeOutCurrentLevel
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int _CurrentLevelType
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int _TallestCompletedLv
	{
		get
		{
			return 0;
		}
		private set
		{
		}
	}

	public static bool MultiTouch => false;

	public static bool BeGyro => false;

	private void Awake()
	{
		_Instance = this;
		Application.targetFrameRate = 60;
		isLevelClear = false;
		if (PlayerPrefs.GetInt("Tips") == 0)
		{
			_Tips = 3;
			PlayerPrefs.SetInt("Tips", 3);
		}
        else
        {
			_Tips = PlayerPrefs.GetInt("Tips");
        }
	}

	
}

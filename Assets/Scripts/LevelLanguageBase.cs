using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLanguageBase : MonoBehaviour
{
	public LevelInfo _LevelGuide;

	[SerializeField]
	protected RectTransform content;

	[SerializeField]
	protected Text _queText;

	protected List<Transform> texTrans;

	protected Vector2 preferredSize;

	public virtual void Init()
	{
		content.localPosition = new Vector3(0,675,0);
		_queText.GetComponent<RectTransform>().localPosition = Vector3.zero;
		_queText.fontSize = 70;
		_queText.text = GleyLocalization.Manager.GetText("LevelContent" + LevelManager._Instance.currentLevel);
	}

	public virtual void AddTexTrans(Transform[] para)
	{
	}

	public virtual void RepaireTextSize(float scale)
	{
	}

	public virtual void UpdatePos()
	{
	}

	public virtual void UpdateQueTextAlign()
	{
	}

	public virtual void UpdatePanel()
	{
	}

	public void UpdateText()
    {
		_queText.text = GleyLocalization.Manager.GetText("LevelContent" + LevelManager._Instance.currentLevel);
	}
}

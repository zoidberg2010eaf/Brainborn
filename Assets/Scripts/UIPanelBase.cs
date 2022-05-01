using UnityEngine;


public class UIPanelBase : MonoBehaviour
{
	private string _panelName;

	private RectTransform _rectTransform;

	public string _LastPanel;

	public string _NextPanel;

	protected bool isHide;

	

	protected bool once;

	public string _PanelName;

	public RectTransform _RectTransform => GetComponent<RectTransform>();

	public virtual void UpdatePanel()
	{
	}

	public virtual void UpdateText()
	{
	}

	public virtual void UpdateTips()
	{
		
	}

	public virtual void Show()
	{
	}

	protected virtual void UpdateShareRect()
	{
	}

	public virtual void Show(object para)
	{
	}

	public virtual void Hide()
	{
	}

	public virtual bool IsHide()
	{
		return false;
	}

	public virtual void Escape()
	{
	}
}

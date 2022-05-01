using UnityEngine;

public class OptionBase : MonoBehaviour
{
	public float _Width;

	public float _Height;

	private RectTransform rectTransform;

	public RectTransform _RectTransform
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual void UpdateSize()
	{
	}

	public virtual void UpdateSize(float width, float height)
	{
	}

	public virtual void UpdateSize(Vector2 vector)
	{
	}
}

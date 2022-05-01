using UnityEngine;
using UnityEngine.UI;
using GleyLocalization;

public class LanOption : MonoBehaviour
{
	[SerializeField]
	private Text thisText;

	private SupportedLanguages _value;

	public Button thisBtn;

	public void UpdateText(SupportedLanguages value, bool isTh = false, bool isAr = false)
	{
		thisText.text = value.ToString();
		_value = value;
	}

	public void UpdateCol(Color color)
	{
		thisText.color = color;
	}

	public void SetLanguage()
    {
		if(_value.ToString() != "")
		 LocalizationManager.Instance.SetCurrentLanguage(_value);
		LanPanel.instance.UpdatePanel();
    }
}

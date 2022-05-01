using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Stage12 : BaseStage
{
    public InputField _inputField;

    public string _result;

    public Text _fieldHint;

    public Text _okText;

    public override void PrepareView()
    {
        _fieldHint.text = GleyLocalization.Manager.GetText("input_guide");
        _okText.text = GleyLocalization.Manager.GetText("level_ok");
    }

    // Start is called before the first frame update
    void Start()
    {
        PrepareView();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckResult()
    {
        if (_inputField.text == _result)
        {
            AnswerRight(Vector2.zero);
        }
        else
            AnswerWrong(Vector2.zero);
    }

    public void OnDragItem(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;
        Vector2 delta = pointerEventData.delta;
        GameObject pointerDrag = pointerEventData.pointerDrag;
        if (UnityEngine.Input.touchCount <= 1)
        {
            pointerDrag.GetComponent<RectTransform>().anchoredPosition =
            new Vector2(pointerDrag.GetComponent<RectTransform>().anchoredPosition.x + delta.x * (2272f / (float)Screen.height),
            pointerDrag.GetComponent<RectTransform>().anchoredPosition.y + delta.y * (2272f / (float)Screen.height));
        }
    }
}

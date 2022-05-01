using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Stage7 : BaseStage
{
    public Text _clearTxt, _okTxt;

    public Text _resultTxt;

    private int currentResult;

    public int _result;

    public override void PrepareView()
    {

        _clearTxt.text = GleyLocalization.Manager.GetText("level_clear");
        _okTxt.text = GleyLocalization.Manager.GetText("level_ok");

    }

    // Start is called before the first frame update
    void Start()
    {
        PrepareView();
        currentResult = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _resultTxt.text = currentResult.ToString();
    }

    public void NextResult()
    {
        currentResult++;
    }

    public void PreviousResult()
    {
        if (currentResult > 0)
            currentResult--;
    }

    public void ClearResult()
    {
        currentResult = 0;
    }

    public void CheckResult()
    {
        if (currentResult == _result)
            AnswerRight(Vector2.zero);
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

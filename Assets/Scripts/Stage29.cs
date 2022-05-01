using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Stage29 : BaseStage
{
    public RectTransform _cloud1,_cloud2, _text, _result;

    public Image _stone;

    public Sprite _ice;

    private bool _finish;
    // Start is called before the first frame update
    void Start()
    {
        _finish = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckContain();
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

    public override void PrepareView()
    {
       
    }

    public void CheckContain()
    {
       if(!_finish)
        {
            
            if (RectTransformUtility.RectangleContainsScreenPoint(this._result, GameHelper.CanvasToScreenPoint(_cloud1), Camera.main))
                return;
            if (RectTransformUtility.RectangleContainsScreenPoint(this._result, GameHelper.CanvasToScreenPoint(_cloud2), Camera.main))
                return;
            if (RectTransformUtility.RectangleContainsScreenPoint(this._result, GameHelper.CanvasToScreenPoint(_text), Camera.main))
                return;
            _finish = true;
            StartCoroutine(ShowRight());
        }
      
    }

    IEnumerator ShowRight()
    {
      
        _stone.sprite = _ice;
        yield return new WaitForSeconds(1.0f);
        AnswerRight(Vector2.zero);
    }
}

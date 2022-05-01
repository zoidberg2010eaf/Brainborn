using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stage21 : BaseStage
{
    public RectTransform resultObj1, resultObj2;

    public RectTransform _star, _moon, _face, _house;

    private bool _canMove;

    public override void PrepareView()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckResult();
    }

    public void OnDragItem(BaseEventData eventData)
    {
        if (!_canMove)
            return;
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

    public void CheckResult()
    {
        if (!_canMove)
            return;
        if (RectTransformUtility.RectangleContainsScreenPoint(this.resultObj1, GameHelper.CanvasToScreenPoint(_house), Camera.main))
            return;
        if (RectTransformUtility.RectangleContainsScreenPoint(this.resultObj1, GameHelper.CanvasToScreenPoint(_face), Camera.main))
            return;
        if (RectTransformUtility.RectangleContainsScreenPoint(this.resultObj2, GameHelper.CanvasToScreenPoint(_face), Camera.main))
            return;

        if (RectTransformUtility.RectangleContainsScreenPoint(this.resultObj1, GameHelper.CanvasToScreenPoint(resultObj2), Camera.main))
        {
            _canMove = false;
            Vector3 _targetPos = new Vector3(this.resultObj1.anchoredPosition.x, this.resultObj1.anchoredPosition.y, 0.0f);
            LeanTween.move(this.resultObj2, _targetPos, 0.3f);
            StartCoroutine(ShowAnswer());

        }
    }

    IEnumerator ShowAnswer()
    {
        yield return new WaitForSeconds(1.0f);
        base.AnswerRight(GameHelper.CanvasToScreenPoint(this.resultObj2).ToCanvasPoint());
    }
}

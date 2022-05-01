using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stage6 : BaseStage
{
    public RectTransform resultObj1, resultObj2;

    private bool m_canMove;

    // Start is called before the first frame update
    void Start()
    {
        m_canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDragResult(BaseEventData eventData)
    {
        if (!this.m_canMove)
            return;

        PointerEventData pointerEventData = (PointerEventData)eventData;
        Vector2 delta = pointerEventData.delta;
        GameObject pointerDrag = pointerEventData.pointerDrag;
        pointerDrag.GetComponent<RectTransform>().anchoredPosition = pointerDrag.GetComponent<RectTransform>().anchoredPosition + delta * (2272f / (float)Screen.height);
       
    }

    public void OnEndDragResult(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;
        GameObject pointerDrag = pointerEventData.pointerDrag;
        RectTransform component = pointerDrag.GetComponent<RectTransform>();
        Debug.Log("CLICK " + pointerDrag.name);
        if (RectTransformUtility.RectangleContainsScreenPoint(this.resultObj1, pointerEventData.position, Camera.main))
        {
            this.m_canMove = false;
            Vector3 _targetPos = new Vector3(this.resultObj1.anchoredPosition.x, this.resultObj1.anchoredPosition.y + 20.0f, 0.0f);
            LeanTween.move(component, _targetPos, 0.3f);
            base.AnswerRight(component.localPosition);
            //base.StartCoroutine(“WordAnimation”);
        }
       
    }

    public void OnEndDragResult1(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;
        GameObject pointerDrag = pointerEventData.pointerDrag;
        RectTransform component = pointerDrag.GetComponent<RectTransform>();
       // Debug.Log("CLEAR " + GameHelper.CanvasToScreenPoint(resultObj2));
        if (RectTransformUtility.RectangleContainsScreenPoint(this.resultObj1, GameHelper.CanvasToScreenPoint(resultObj2), Camera.main))
        {
            this.m_canMove = false;
            
            Vector3 _targetPos = new Vector3(this.resultObj1.anchoredPosition.x, this.resultObj1.anchoredPosition.y + 20.0f, 0.0f);
            LeanTween.move(this.resultObj2, _targetPos, 0.3f);
            base.AnswerRight(component.localPosition);

            // Debug.Log("CLEAR");

        }
      
    }

    public void OnBeginDragResult(BaseEventData eventData)
    {
       
    }

    public override void PrepareView()
    {
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stage28 : BaseStage
{
    public RectTransform _balance;
    public override void PrepareView()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDragItem(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;
        Vector2 delta = pointerEventData.delta;
        GameObject pointerDrag = pointerEventData.pointerDrag;
        if (UnityEngine.Input.touchCount <= 1)
        {
            
            if(pointerDrag.GetComponent<RectTransform>().anchoredPosition.x > -45.0f)
            {
                _balance.localRotation = Quaternion.Euler(0, 0, -25.0f);
                pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                new Vector2(-45.0f,
                pointerDrag.GetComponent<RectTransform>().anchoredPosition.y);
                AnswerRight(Vector2.zero);
            }
                
            else if (pointerDrag.GetComponent<RectTransform>().anchoredPosition.x < -445.0f)
                pointerDrag.GetComponent<RectTransform>().anchoredPosition =
           new Vector2(-445.0f,
           pointerDrag.GetComponent<RectTransform>().anchoredPosition.y);
            else
                pointerDrag.GetComponent<RectTransform>().anchoredPosition =
            new Vector2(pointerDrag.GetComponent<RectTransform>().anchoredPosition.x + delta.x * (2272f / (float)Screen.height),
            pointerDrag.GetComponent<RectTransform>().anchoredPosition.y);

           
        }
    }
}

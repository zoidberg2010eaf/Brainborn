using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stage8 : BaseStage
{
    public RectTransform mainObject;

    public List<RectTransform> objectList;

    private int currentSize;

    // Start is called before the first frame update
    void Start()
    {
        currentSize = 0;
    }

    // Update is called once per frame
    void Update()
    {

        CheckDistance();
    }

    void CheckDistance()
    {
        for(int i = 0; i < objectList.Count; i++)
        {
            if (Vector3.Distance(mainObject.transform.localPosition, objectList[i].transform.localPosition) < 200.0f)
            {
                
                Destroy(objectList[i].gameObject);
                objectList.RemoveAt(i);
                mainObject.transform.localScale *= 1.15f;
                currentSize++;
            }
               
        }
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

    public void CheckResult(BaseEventData eventData)
    {
        if(currentSize == 3)
        {
            AnswerRight(eventData);
        }    
    }

    public override void PrepareView()
    {
       
    }
}

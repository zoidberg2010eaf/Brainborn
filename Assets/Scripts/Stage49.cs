using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stage49 : BaseStage
{
    public GameObject _mum;
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

        if (delta.x >= 20.0f || delta.y >= 20)
        {
            _mum.SetActive(true);
            AnswerRight(Vector2.zero);
        }
    }
}

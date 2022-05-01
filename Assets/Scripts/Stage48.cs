using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stage48 : BaseStage
{
    public GameObject _lamp,_content;

    public bool _touchLamp;

    public override void PrepareView()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        _touchLamp = false;   
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
       
        if(delta.x >= 20.0f || delta.y >= 20)
        {
            _lamp.SetActive(true);
            _content.SetActive(true);
            _touchLamp = true;
        }
    }

    public void ClickBook()
    {
        if (_touchLamp)
            AnswerRight(Vector2.zero);
    }

    public void ChooseDream()
    {
        AnswerWrong(Vector2.zero);
        Reset();
    }

    public void Reset()
    {
        _touchLamp = false;
        _lamp.SetActive(false);
        _content.SetActive(false);
    }

}

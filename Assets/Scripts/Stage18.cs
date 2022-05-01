using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Stage18 : BaseStage
{
    private float _start, _end;

    public GameObject _deer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPress(BaseEventData eventData)
    {
        
        PointerEventData pointerEventData = (PointerEventData)eventData;
        _start =   pointerEventData.position.ToCanvasPoint().y;
       
    }    

    public void ReleasePress(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;
        _end = pointerEventData.position.ToCanvasPoint().y;

        if (_end - _start >= 50.0f)
        {
            _deer.GetComponent<RectTransform>().localScale = new Vector3(1,1.2f,1);
            _deer.GetComponent<Image>().pixelsPerUnitMultiplier = 1.05f;
        
            AnswerRight(Vector2.zero);
        }
            
    }

    public override void PrepareView()
    {
       
    }
}

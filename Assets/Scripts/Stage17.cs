using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Stage17 : BaseStage
{

    public List<Egg> _eggList;

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

    public void HitEgg(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;
        Vector2 delta = pointerEventData.delta;
        GameObject pointerDrag = pointerEventData.pointerDrag;
        int _id = pointerDrag.GetComponent<Egg>()._id;
        
            _eggList[_id]._click++;

     
            if (_eggList[_id]._click >= 5 && _id == 0)
            {
                AnswerRight(eventData);
                _eggList[_id].eggImage.sprite = _eggList[_id].brokenSpr1;
               _eggList[_id].eggImage.SetNativeSize();
            }
                
            else
            {
               _eggList[_id].eggImage.sprite = _eggList[_id].brokenSpr2;
            _eggList[_id].eggImage.SetNativeSize();
            AnswerWrong(eventData);
            }
               
        
    }    
}

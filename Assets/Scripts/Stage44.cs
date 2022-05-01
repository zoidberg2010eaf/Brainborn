using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Stage44 : BaseStage
{
    public RectTransform _tar1, _tar2;

    private bool _getObject;

    public Image _man;

    public Sprite _manFinish;

    public RectTransform o1, o2, o3, o4, o5;

    public Vector3 or1, or2, or3, or4,or5;

    // Start is called before the first frame update
    void Start()
    {
        _getObject = false;
        or1 = o1.localPosition;
        or2 = o2.localPosition;
        or3 = o3.localPosition;
        or4 = o4.localPosition;
        or5 = o5.localPosition;

    }
   

// Update is called once per frame
   void Update()
    {
        if (Vector3.Distance(_tar1.localPosition, _tar2.localPosition) < 100.0f && !_getObject)
        {
            _getObject = true;
            _man.sprite = _manFinish;
            _tar2.gameObject.SetActive(false);
            AnswerRight(Vector2.zero);
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

    public void ResetPos()
    {
        o1.localPosition = or1;
        o2.localPosition = or2;
        o3.localPosition = or3;
        o4.localPosition = or4;
    }

    public void ResetNotice()
    {
         if (Vector3.Distance(_tar1.localPosition, _tar2.localPosition) >= 100.0f)
            o5.localPosition = or5;
    }

    public override void PrepareView()
    {
        throw new System.NotImplementedException();
    }
}

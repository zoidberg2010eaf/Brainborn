using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stage45 : BaseStage
{
    public RectTransform o1, o2, o3, o4, o5;

    Vector3 or1, or2, or3, or4, or5, _ship;

    public RectTransform _tar1, _tar2;

    private bool _getObject;

    public GameObject mask;

    // Start is called before the first frame update
    void Start()
    {
        or1 = o1.localPosition;
        or2 = o2.localPosition;
        or3 = o3.localPosition;
        or4 = o4.localPosition;
        or5 = o5.localPosition;
        _ship = _tar2.localPosition;
        _getObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_tar1.localPosition, _tar2.localPosition) < 200.0f && !_getObject)
        {
            _getObject = true;
            _tar2.localPosition = new Vector3(_tar1.localPosition.x, _tar1.localPosition.y + 360.0f, _tar1.localPosition.z);
            mask.SetActive(false);
            AnswerRight(Vector2.zero);
        }
    }

    public void OnDragItem(BaseEventData eventData)
    {
        if (_getObject)
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

    public override void PrepareView()
    {
        throw new System.NotImplementedException();
    }


    public void ResetPos()
    {
        o1.localPosition = or1;
        o2.localPosition = or2;
        o3.localPosition = or3;
        o4.localPosition = or4;
        o5.localPosition = or5;
    }

    public void ResetShip()
    {
        if (Vector3.Distance(_tar1.localPosition, _tar2.localPosition) >= 200.0f && !_getObject)
        
            _tar2.localPosition = _ship;
    }
}

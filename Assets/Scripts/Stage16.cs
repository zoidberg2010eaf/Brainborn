using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stage16 : BaseStage
{

    public float _zoomSpeed;

    public RectTransform _zoomObject,_dragObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // zoom

            if ((_zoomObject.localScale - deltaMagnitudeDiff * _zoomSpeed * Vector3.one).x > 0)
               _zoomObject.localScale -= deltaMagnitudeDiff * _zoomSpeed * Vector3.one;
           
           
        }

        CheckResult();

    }

    public void CheckResult()
    {
        
        if(Vector3.Distance(_zoomObject.localPosition, _dragObject.localPosition) < 50.0f &&  _zoomObject.localScale.x >= 1.0f)
        {
           // Debug.Log("Scale " + _zoomObject.localScale.x);
            AnswerRight(Vector3.zero);
        }
    }

    public override void PrepareView()
    {
       
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
}

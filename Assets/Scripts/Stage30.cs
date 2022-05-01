using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage30 : BaseStage
{
    public float _zoomSpeed;

    public RectTransform _zoomObject;
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
            if ((_zoomObject.localScale - deltaMagnitudeDiff * _zoomSpeed * Vector3.one).x > 1.0f)
                AnswerRight(Vector2.zero);


        }
    }
}

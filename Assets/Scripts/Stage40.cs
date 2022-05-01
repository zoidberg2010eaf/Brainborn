using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Stage40 : BaseStage
{
    public bool[] _state;

    public Image[] _lightImage;

    public Sprite _lightOn, _lightOff;

    public RectTransform mainObject;

    // Start is called before the first frame update
    void Start()
    {
        _state[0] = _state[1] = _state[2] = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameHelper.CanvasToScreenPoint(mainObject).x > Screen.width + 20.0f || GameHelper.CanvasToScreenPoint(mainObject).x < -20.0f ||
           GameHelper.CanvasToScreenPoint(mainObject).y < -20.0f || GameHelper.CanvasToScreenPoint(mainObject).y > 20.0f + Screen.height)
        {
            if(_state[0] && _state[1])
            {
                AnswerRight(Vector2.zero);
               _lightImage[2].gameObject.SetActive(false);
            }
        }
    }

    public void Toggle(int _index)
    {
        if(_state[_index])
        {
            _state[_index] = false;
            _lightImage[_index].sprite = _lightOff;
        }
        else
        {
            if((_state[0] && _state[1])
                || (_state[0] && _state[2])
                || (_state[1] && _state[2]))
            {

            }
            else
            {
                _state[_index] = true;
                _lightImage[_index].sprite = _lightOn;
            }
           
        }

        if (_state[0] && _state[1] && !_lightImage[2].gameObject.activeSelf)
        {
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

    public override void PrepareView()
    {
       
    }
}

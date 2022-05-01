using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Stage32 : BaseStage
{
    public GameObject _noodleObj, _cupObj, _water1, _water2;

    public Sprite _cupHasNoodle,_cupHasBoth;

    public bool _hasWater, _hasNoodle, _startTimer;

    public float _timer;

    // Start is called before the first frame update
    void Start()
    {
        _hasNoodle = _hasWater = _startTimer = false;
        _timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(_noodleObj.transform.localPosition, _cupObj.transform.localPosition) < 150.0f && !_hasNoodle)
        {
            _noodleObj.gameObject.SetActive(false);
            _cupObj.GetComponent<Image>().sprite = _cupHasNoodle;
            _hasNoodle = true;
        }
          

        if (Vector3.Distance(_water1.transform.localPosition, _cupObj.transform.localPosition) < 150.0f && !_hasWater)
        {
            _water1.gameObject.SetActive(false);
            _water2.gameObject.SetActive(true);
            _hasWater = true;
        }

        if (_hasWater && _hasNoodle)

            _cupObj.GetComponent<Image>().sprite = _cupHasBoth;

       
        if(_startTimer)
           _timer += Time.deltaTime;
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

    public void Press()
    {
        if (_hasNoodle && _hasNoodle)
            _startTimer = true;
        
    }

    public void UnPress()
    {
      
        if (_timer >= 3.0f && _hasNoodle && _hasNoodle)
            AnswerRight(Vector2.zero);

        _startTimer = false;
        _timer = 0.0f;
    }

    public override void PrepareView()
    {
        
    }
}

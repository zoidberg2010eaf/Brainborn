using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stage19 : BaseStage
{
    private int _touchTotal;

    [SerializeField]
    private GameObject _smoke;

    [SerializeField]
    private GameObject _cirgaret;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tap()
    {
        _touchTotal++;

        if(_touchTotal >= 5)
        {
            _smoke.SetActive(false);
            _cirgaret.SetActive(false);
            AnswerRight(Vector2.zero);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stage39 : BaseStage
{
    public RectTransform[] _result;

    public bool[] _resultToggle;



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

    public void Choose(int _index)
    {
        _result[_index].gameObject.SetActive(true);
        _resultToggle[_index] = true;

        for(int i = 0; i < _resultToggle.Length; i++)
        {
            if (!_resultToggle[i])
            {
                Debug.Log(" i " + i.ToString());
                return;
            }
                
        }

        AnswerRight(Vector2.zero);
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

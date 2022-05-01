using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stage9 : BaseStage
{
    public RectTransform mainObject;

    private bool _isClear;

    public override void PrepareView()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        _isClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("SUN " + GameHelper.CanvasToScreenPoint(mainObject) + "   /" + Screen.width);
        if (GameHelper.CanvasToScreenPoint(mainObject).x > Screen.width + 20.0f || GameHelper.CanvasToScreenPoint(mainObject).x < -20.0f ||
            GameHelper.CanvasToScreenPoint(mainObject).y < -20.0f || GameHelper.CanvasToScreenPoint(mainObject).y > 20.0f + Screen.height)
        {
           if(!_isClear)
            {
                _isClear = true;
                StartCoroutine(ShowClear());
            }
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

    IEnumerator ShowClear()
    {
        Camera.main.backgroundColor = Color.gray;
        yield return new WaitForSeconds(0.5f);
        AnswerRight(Vector2.zero);
        yield return new WaitForSeconds(3.0f);
        Camera.main.backgroundColor = Color.white;
      
    }    
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stage26 : BaseStage
{
    private bool _finish, _isChecking;

    private bool choose1, choose2;

    public GameObject _result1, _result2;

    public override void PrepareView()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        _finish = _isChecking = choose1 = choose2 = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Click(BaseEventData eventData)
    {
        if (_finish)
            return;
        PointerEventData pointerEventData = (PointerEventData)eventData;

        GameObject pointerDrag = pointerEventData.pointerDrag;

        if (pointerDrag.name == "result1")
            choose1 = true;
        if (pointerDrag.name == "result2")
            choose2 = true;

        if (!_isChecking)
            StartCoroutine(ChekingResult());

    }

    IEnumerator ChekingResult()
    {

        _isChecking = true;
        yield return new WaitForSeconds(0.25f);
        if (choose1 && choose2)
        {
            _result1.SetActive(false);
            _result2.SetActive(true);
            AnswerRight(Vector2.zero);
        }
           
        else
        {
            AnswerWrong(Vector2.zero);
            _finish = _isChecking = choose1 = choose2 = false;
        }
           
    }
}

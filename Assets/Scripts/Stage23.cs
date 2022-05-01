using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stage23 : BaseStage
{
    public List<RectTransform> _squareList;

    public List<GameObject> _markList;

    private bool _finish, _isChecking;

    // Start is called before the first frame update
    void Start()
    {
        _finish = false;
        _isChecking = false;
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
                
            pointerDrag.transform.Find("ImageO").gameObject.SetActive(true);

           if (!_isChecking)
            StartCoroutine(ChekingResult());
            

    }    

    IEnumerator ChekingResult()
    {

        _isChecking = true;
        yield return new WaitForSeconds(0.25f);

        if (_squareList[2].Find("ImageO").gameObject.activeSelf && _squareList[8].Find("ImageO").gameObject.activeSelf)
        {
            _finish = true;
            AnswerRight(Vector2.zero);
          
        }

        if (_squareList[3].Find("ImageO").gameObject.activeSelf && _squareList[4].Find("ImageO").gameObject.activeSelf)
        {
            _finish = true;
            AnswerRight(Vector2.zero);
            
        }

        if (_squareList[2].Find("ImageO").gameObject.activeSelf)
        {

            Click1();
      
        }

        if (_squareList[3].Find("ImageO").gameObject.activeSelf)
        {

            Click2();

        }
        if (_squareList[4].Find("ImageO").gameObject.activeSelf)
        {

            Click3();

        }
        if (_squareList[8].Find("ImageO").gameObject.activeSelf)
        {

            Click4();

        }

    }    

    public void Click1()
    {
        if (_finish)
            return;
        else
        {
            _finish = true;
            _squareList[2].Find("ImageO").gameObject.SetActive(true);
            StartCoroutine(Answer1());
        }
       
    }

    public void Click2()
    {
        if (_finish)
            return;
        else
        {
            _finish = true;
            _squareList[3].Find("ImageO").gameObject.SetActive(true);
            StartCoroutine(Answer2());
        }
    }

    public void Click3()
    {
            if (_finish)
                return;
            else
            {
                _finish = true;
                _squareList[4].Find("ImageO").gameObject.SetActive(true);
                StartCoroutine(Answer3());
            }
    }

    public void Click4()
    {
                if (_finish)
                    return;
                else
                {
                    _finish = true;
                    _squareList[8].Find("ImageO").gameObject.SetActive(true);
                    StartCoroutine(Answer4());
                }
    }

    IEnumerator Answer1()
    {
        yield return new WaitForSeconds(0.25f);
        _squareList[3].Find("ImageX").gameObject.SetActive(true);
        _markList[1].SetActive(true);
        StartCoroutine(ShowWrong());
    }

    IEnumerator Answer2()
    {
        yield return new WaitForSeconds(0.25f);
        _squareList[2].Find("ImageX").gameObject.SetActive(true);
        _markList[0].SetActive(true);
        StartCoroutine(ShowWrong());
    }


    IEnumerator Answer3()
    {
        yield return new WaitForSeconds(0.25f);
        _squareList[2].Find("ImageX").gameObject.SetActive(true);
        _markList[0].SetActive(true);
        StartCoroutine(ShowWrong());
    }

    IEnumerator Answer4()
    {
        yield return new WaitForSeconds(0.25f);
        _squareList[3].Find("ImageX").gameObject.SetActive(true);
        _markList[1].SetActive(true);
        StartCoroutine(ShowWrong());
    }

    IEnumerator ShowWrong()
    {
        yield return new WaitForSeconds(0.25f);
        AnswerWrong(Vector2.zero);
        yield return new WaitForSeconds(0.25f);
        ResetGame();
    }

    void ResetGame()
    {
        _markList[0].SetActive(false);
        _markList[1].SetActive(false);
        _markList[2].SetActive(false);
        _markList[3].SetActive(false);
        _squareList[2].Find("ImageX").gameObject.SetActive(false);
        _squareList[2].Find("ImageO").gameObject.SetActive(false);
        _squareList[3].Find("ImageX").gameObject.SetActive(false);
        _squareList[3].Find("ImageO").gameObject.SetActive(false);
        _squareList[4].Find("ImageX").gameObject.SetActive(false);
        _squareList[4].Find("ImageO").gameObject.SetActive(false);
        _squareList[8].Find("ImageX").gameObject.SetActive(false);
        _squareList[8].Find("ImageO").gameObject.SetActive(false);
        _finish = false;
        _isChecking = false;
    }

    public override void PrepareView()
    {
       
    }
}

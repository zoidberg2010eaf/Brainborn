using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage47 : BaseStage
{
    public int _orangleNum, _greenNum;

    public Text _orangleTxt, _greenTxt;

    public GameObject fake;

    public override void PrepareView()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        _orangleNum = _greenNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountOrangle()
    {
        _orangleNum++;
        _orangleTxt.text = _orangleNum.ToString();
    }

    public void CountGreen()
    {
        if(_orangleNum != 3)
        {
            AnswerWrong(Vector2.zero);
            Reset();
            return;
        }
        if (_greenNum < 5)
        {

            _greenNum++;
            _greenTxt.text = _greenNum.ToString();

        }
        if (_greenNum == 3)
        {
            fake.SetActive(true);
            StartCoroutine(DisableGreen());
        }
        else if(_greenNum == 5)
        {
            AnswerRight(Vector2.zero);
        }
    }

    IEnumerator DisableGreen()
    {
        yield return new WaitForSeconds(3.0f);
        fake.SetActive(false);
    }

    public void WrongClick()
    {
        AnswerWrong(Vector2.zero);
        Reset();
    }

    public void Reset()
    {
        _orangleNum = _greenNum = 0;
        _greenTxt.text = _greenNum.ToString();
        _orangleTxt.text = _orangleNum.ToString();
        fake.SetActive(false);
    }
}

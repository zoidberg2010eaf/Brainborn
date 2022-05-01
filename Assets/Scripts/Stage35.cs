using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage35 : BaseStage
{
    public List<RectTransform> inputRoot;

    public List<RectTransform> numberList;

    private int _inputIndex;

    public string _result;

    public Text _okTxt;

    public override void PrepareView()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        _inputIndex = 0;
        _result = "";
        _okTxt.text = GleyLocalization.Manager.GetText("level_ok");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNumber(int _num)
    {
        numberList[_num].parent = inputRoot[_inputIndex];
        if(_num == 0 || _num == 1)
        numberList[_num].GetComponent<Image>().raycastTarget = false;
        else
            numberList[_num].GetComponent<Text>().raycastTarget = false;
        numberList[_num].localPosition = Vector3.zero;
        if (_num == 0 || _num == 1)
            _result = _result + "o";
        else
            _result = _result + numberList[_num].GetComponent<Text>().text;
        _inputIndex++;
    }

    public void Check()
    {
        if (_result == "oo")
            AnswerRight(Vector2.zero);
        else
            AnswerWrong(Vector2.zero);
    }
}

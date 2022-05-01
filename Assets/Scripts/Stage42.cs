using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage42 : BaseStage
{
    string _result = "";

    public string endResult;

    public Text inputText;

    public RectTransform _target, _anchor;

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

    public void Input(int _num)
    {
        if(_result.Length <= 12)
        {
            if (_result == "0")
                _result = "";
            _result += _num.ToString();
            inputText.text = _result.ToString();
        }
       
    }

    public void Clear()
    {
        if (_result.Length > 0)
        {
            _result = "0";
            inputText.text = _result.ToString();
        }

    }

    public void Check()
    {
        if (endResult == _result)
        {
            AnswerRight(Vector2.zero);
            _target.localPosition = _anchor.localPosition;
        }
            
        else
            AnswerWrong(Vector2.zero);
    }
}

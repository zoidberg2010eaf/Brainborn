using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage43 : BaseStage
{
    public string _result;

    public Text _resultText;

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

    public void Check()
    {
        if (_resultText.text == _result)
            AnswerRight(Vector2.zero);
        else
            AnswerWrong(Vector2.zero);
    }
}

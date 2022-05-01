using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage46 :BaseStage
{
    public Image _paint;

    float _paintAlpha;

    public override void PrepareView()
    {
        _paintAlpha = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        _paintAlpha = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveAlphaPaint()
    {
        if(_paintAlpha >= 0)
        {
            _paintAlpha -= 0.1f;
            _paint.color = new Color(1.0f, 1.0f, 1.0f, _paintAlpha);
        }
        else
        {
            AnswerRight(Vector2.zero);
        }
       
    }
}

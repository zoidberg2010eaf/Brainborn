using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage38 :BaseStage
{
    public Text _numTxt1, _numTxt2;

    public int _start1, _start2;
    public override void PrepareView()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _start1 = 1;
        _start2 = 0;
        _numTxt1.gameObject.SetActive(false);
        _numTxt2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_start1 == 11 && _start2 == 1)
            AnswerRight(Vector2.zero);
    }

    public void Click1()
    {
        _numTxt1.gameObject.SetActive(true);
        _start1++;
        _numTxt1.text = _start1.ToString();
    }

    public void Click2()
    {
        _numTxt2.gameObject.SetActive(true);
        _start2++;
        _numTxt2.text = _start2.ToString();
    }
}

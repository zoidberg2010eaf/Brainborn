using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage37 :BaseStage
{

    public GameObject _result1, _result2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_result1.activeSelf && _result2.activeSelf)
            AnswerRight(Vector2.zero);
    }

    public void TapObject1()
    {
        _result1.SetActive(true);
    }

    public void TapObject2()
    {
        _result2.SetActive(true);
    }

    public override void PrepareView()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage41 : BaseStage
{
    public Image _lamp;

    public Sprite _on, _off;

    // Start is called before the first frame update
    void Start()
    {
    }
    public override void PrepareView()
    {
        
    }

// Update is called once per frame
   void Update()
    {
        
    }

    public void ClickOn()
    {
        _lamp.sprite = _on;
        StartCoroutine(LampOn());
    }

    IEnumerator LampOn()
    {
        yield return new WaitForSeconds(1.0f);
        AnswerRight(Vector2.zero);
    }
}

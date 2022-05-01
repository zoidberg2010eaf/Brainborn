using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Stage22 : BaseStage
{
    private bool _isRotate;

    public List<Image> _fishList;

    public Image _result;

    public Sprite _noFish,_normal;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Image _image in _fishList)
        {
            _image.sprite = _normal;
            _image.SetNativeSize();
        }
           
        _result.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     
        if(Input.acceleration.y >= 0.9f)
        {
            if (_isRotate)
                return;
            _isRotate = true;
            ShowFish();
        }
    }

    void ShowFish()
    {
        foreach (Image _image in _fishList)
        {
            _image.sprite = _noFish;
            _image.SetNativeSize();
        }
           
        _result.gameObject.SetActive(true);
    }

    public void ShowWrong(BaseEventData eventData)
    {
        
            AnswerWrong(eventData);       
       
    }

    public void ShowCorrect(BaseEventData eventData)
    {
        if (!_isRotate)
        {
            AnswerWrong(eventData);
        }
        else
           AnswerRight(eventData);
    }

    public override void PrepareView()
    {
       
    }
}

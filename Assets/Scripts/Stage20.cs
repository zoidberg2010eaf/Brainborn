using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Stage20 : BaseStage
{

    public RectTransform _hole;

    public RectTransform[] _coinList;

    private int _coinDropTotal;

    private bool _dropComplete;

    private int _tapToPig;

    public Image _pigImage;

    public Sprite _brokenPig;

    public InputField _inputField;

    public string _result;

    public Text _fieldHint;

    public Text _okText;



    public override void PrepareView()
    {
        _fieldHint.text = GleyLocalization.Manager.GetText("input_guide");
        _okText.text = GleyLocalization.Manager.GetText("level_ok");
    }

    // Start is called before the first frame update
    void Start()
    {
        _coinDropTotal = 0;
        _dropComplete = false;
        _tapToPig = 0;
        PrepareView();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCoinInHole();
    }

    public void OnDragItem(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;
        Vector2 delta = pointerEventData.delta;
        GameObject pointerDrag = pointerEventData.pointerDrag;
        if (UnityEngine.Input.touchCount <= 1)
        {
            pointerDrag.GetComponent<RectTransform>().anchoredPosition =
            new Vector2(pointerDrag.GetComponent<RectTransform>().anchoredPosition.x + delta.x * (2272f / (float)Screen.height),
            pointerDrag.GetComponent<RectTransform>().anchoredPosition.y + delta.y * (2272f / (float)Screen.height));
        }
    }

    public void CheckCoinInHole()
    {
        if (_dropComplete)
            return;

        for(int i = 0; i < _coinList.Length; i++)
        {
            if(_coinList[i] != null)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(_hole, GameHelper.CanvasToScreenPoint(_coinList[i]), Camera.main))
                {
                    Destroy(_coinList[i].gameObject);
                    _coinDropTotal++;
                }
            }
        }

        if (_coinDropTotal >= 3)
            _dropComplete = true;

    }

    public void TapPig()
    {
        _tapToPig++;

        if(_tapToPig >= 5)
        {
            // AnswerRight(Vector3.zero);
            _pigImage.sprite = _brokenPig;
            _pigImage.SetNativeSize();
        }
    }

    public void CheckResult()
    {
        if (!_dropComplete)
            return;

        if (_inputField.text == _result)
        {
            AnswerRight(Vector2.zero);
        }
        else
            AnswerWrong(Vector2.zero);
    }
}

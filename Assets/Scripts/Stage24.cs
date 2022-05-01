using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage24 : BaseStage
{

    public List<GameObject> _resultList;

    public override void PrepareView()
    {
        for(int i = 0; i < _resultList.Count; i ++)
        {
            _resultList[i].GetComponent<RectTransform>().Find("ImageO").gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PrepareView();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckResult())
            AnswerRight(Vector2.zero);
    }

    public bool CheckResult()
    {
        bool _check = true;

        for (int i = 0; i < _resultList.Count; i++)
        {
            if (!_resultList[i].GetComponent<RectTransform>().Find("ImageO").gameObject.activeSelf)
            {
                _check = false;
                break;
            }
               
        }

        return _check;
    }

    public void Click(int _id)
    {
        _resultList[_id].GetComponent<RectTransform>().Find("ImageO").gameObject.SetActive(true);
    }
}

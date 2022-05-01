using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage25 : BaseStage
{
    public List<GameObject> _result;

    public List<GameObject> _resultPoint;

    private int _tapToCloud;

    private bool _reachMaxTap;

    public GameObject _cloud, _rain, _water, _worm;

    // Start is called before the first frame update
    void Start()
    {
        _reachMaxTap = false;
        _tapToCloud = 0;
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

        for (int i = 0; i < _resultPoint.Count; i++)
            if (!_resultPoint[i].activeSelf)
            {
                _check = false;
            }
               

        return _check;
    }

    public override void PrepareView()
    {
        
    }

    public void TapCloud()
    {
        if (_reachMaxTap)
            return;
        _tapToCloud++;

        if(_tapToCloud >= 5)
        {
            _reachMaxTap = true;
            _cloud.GetComponent<Image>().color = Color.gray;
            _rain.SetActive(true);
            _water.SetActive(true);
            _worm.SetActive(true);
        }
    }

    public void Click(int _id)
    {
        _resultPoint[_id].SetActive(true);
    }
}

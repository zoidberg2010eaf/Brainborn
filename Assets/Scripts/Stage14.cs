using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage14 : BaseStage
{
    public override void PrepareView()
    {
        
    }

    private float _timer;

    [SerializeField]
    private Image earth;

    [SerializeField]
    private Sprite _bomb;

    [SerializeField]
    private Sprite _earth;

    [SerializeField]
    private Text _timerText;

    // Start is called before the first frame update
    void Start()
    {
        _timer = 0.0f;
        _timerText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > 10.0f)
        {
            _timerText.gameObject.SetActive(true);
            _timerText.text = Mathf.FloorToInt(_timer - 10.0f).ToString();
        }

        if(_timer >= 14)
        {
            _timerText.gameObject.SetActive(false);
            AnswerRight(Vector2.zero);
        }
    }

    public void Press()
    {
        if (_timer <= 10.0f)
        {
            _timer = 0.0f;
            earth.sprite = _bomb;
            AnswerWrong(Vector2.zero);
            StartCoroutine(ResetTheEarth());
        }          
       
    }

    IEnumerator ResetTheEarth()
    {
        yield return new WaitForSeconds(2.0f);
        earth.sprite = _earth;
    }
}

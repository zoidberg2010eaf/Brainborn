using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueSetter : MonoBehaviour
{
    public Text sliderValueText;
    float multiplierValue;

    // Start is called before the first frame update
    void Start()
    {
        multiplierValue = 0;
        GetComponent<Animator>().enabled = true;
    }

    public void SetSliderText(float num)
    {
        sliderValueText.text = "x"+num;
        multiplierValue = num;
    }

  
    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetSliderValue()
    {

        return multiplierValue;

    }
}

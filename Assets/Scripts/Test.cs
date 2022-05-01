using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text _test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _test.text = Input.acceleration.x + "  " +Input.acceleration.y + "  " + Input.acceleration.z;
    }
}

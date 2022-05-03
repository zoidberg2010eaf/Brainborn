using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSql : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoTest());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CoTest()
    {
        int x = 0;
        while (true)
        {
            PlayerPrefs.SetInt("ReviewStatus", x);
            RewardManager.SharedInstance.SetStatusById();
            yield return new WaitForSeconds(2.0f);
            RewardManager.SharedInstance.GetStatusById();
            print(PlayerPrefs.GetInt("StatusResponse"));
            yield return new WaitForSeconds(2.0f);
            x++;
        }
    }
}

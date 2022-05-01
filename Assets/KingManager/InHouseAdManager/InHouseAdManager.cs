using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHouseAdManager : MonoBehaviour
{
    // Start is called before the first frame update
    static InHouseAdManager sharedInstance;
    public static InHouseAdManager SharedInstance
    {
        get
        {
            if (!sharedInstance)
            {
                GameObject obj = new GameObject("InHouseAdManager");
                sharedInstance = obj.AddComponent<InHouseAdManager>();
            }
            return sharedInstance;
        }
    }
    void Start()
    {
        
    }
    public void ShowFullScreenAd(){
        //GameObject obj = Resources.Load<GameObject>("AlertPanel");
        GameObject instance = Instantiate(Resources.Load("InHouseFullScreenAdCanvas", typeof(GameObject))) as GameObject;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

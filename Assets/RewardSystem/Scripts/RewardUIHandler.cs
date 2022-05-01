using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RewardUIHandler : MonoBehaviour
{
    public GameObject conversionCanvas_prefab, notEnoghTxt;
    
    GameObject conversionCanvas;

    public static RewardUIHandler sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        notEnoghTxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenconversionPanel()
    {
        int totalCoins = RewardManager.SharedInstance.totalGems;
        int totalAimRobux = PlayerPrefs.GetInt("robuxToEarn");
        if (totalCoins >= totalAimRobux)
        {
            conversionCanvas = Instantiate(conversionCanvas_prefab);
        }
        else
        {
            notEnoghTxt.SetActive(true);
            Invoke("DisablenotEnoghTxt", 1.5f);
        }
       
    }
    void DisablenotEnoghTxt()
    {
        notEnoghTxt.SetActive(false);
    }
    public void SetTextGems(int totalGems)
    {
        if (conversionCanvas != null)
        {
            conversionCanvas.GetComponent<ConversionHandler>().SetGemsText(totalGems);
        }
       
    }
  
}

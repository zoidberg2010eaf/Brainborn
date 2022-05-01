using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public int totalGems;
    string deviceID;
    string bundleID;
   [Serializable]
    public class UserData
    {
        public int id;
        public string userId;
        public int points;
    }
    UserData myUser=new UserData();

    private static RewardManager sharedInstance;
    public static RewardManager SharedInstance
    {
        get
        {
            if (!sharedInstance)
            {
                GameObject rewardManagerObj = new GameObject("SharedAdManager");
                sharedInstance = rewardManagerObj.AddComponent<RewardManager>();
                DontDestroyOnLoad(sharedInstance);
                //sharedInstance.InitializeSDKs();
            }
            return sharedInstance;
        }
    }
    private void Awake()
    {
        deviceID = SystemInfo.deviceUniqueIdentifier;
        bundleID = "" + Application.identifier;
#if UNITY_EDITOR
        {
            deviceID = deviceID.Substring(0, 15);
        }
#endif
        //GetUserData();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int GetGemsDataFromFile()
    {
        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {

            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Debug.Log("path: " + Application.persistentDataPath + "/gamesave.save");
            file.Position = 0;
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            // 3
            Debug.Log("total gems: " + save.totalGems);
            totalGems = save.totalGems;
            return totalGems;
        }
        else
        {
            Debug.Log("No data saved!");
            return 0;
        }
    }
    public void AddPoints(int gemsToAdd)
    {
        Debug.Log("Add points called");
        Debug.Log("bundleID: "+ bundleID);
        string[] dataVlue = { deviceID, gemsToAdd.ToString(),bundleID };
        WebRequestManagerReward.SharedInstance.GetAddPointsWebRequest(dataVlue, AddPointsCallback);
        
       
    }
    void AddGemsToFile(int gems)
    {
        // 1
        Save save = CreateSaveGameObject(gems);

        // 2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Game Saved");
    }
    private Save CreateSaveGameObject(int gems)
    {
       
        Save save = new Save();
        save.totalGems = gems;
       
        Debug.Log("gems after addition: " + save.totalGems);
        return save;
    }
    void AddPointsCallback(string resp)
    {
        Debug.Log("response: " + resp);
        totalGems= int.Parse(resp);
        AddGemsToFile(totalGems);
    }
    public void ExchangeGems(string[] dataValues)
    {
        WebRequestManagerReward.SharedInstance.GetExchangeWebRequest(dataValues, ExchangePointsCallback);
    }
    void ExchangePointsCallback(string resp)
    {
        Debug.Log("response: " + resp);
    }
    public void GetUserData()
    {
        Debug.Log("Get user data called");
        string[] dataVal = { deviceID };
        WebRequestManagerReward.SharedInstance.GetUserDataWebRequest(dataVal, GetUserDataCallback);
    }
    void GetUserDataCallback(string resp)
    {
        Debug.Log("response: " + resp);
        myUser = JsonUtility.FromJson<UserData>(resp);
        Debug.Log("id: " + myUser.id + ", userID: " + myUser.userId + ", points: " + myUser.points);
        totalGems = myUser.points;
        //RewardUIHandler.sharedInstance.SetTextGems(totalGems);
        AddGemsToFile(totalGems);
    }
    public void GetAppReviewStatusById()
    {
        Debug.Log("Get app by id called");
        Debug.Log("bundleID: " + bundleID);
        string[] dataVal = { bundleID };
        WebRequestManagerReward.SharedInstance.GetAppReviewStatus(dataVal, GetAppReviewStatusByIdCallback);
    }
    void GetAppReviewStatusByIdCallback(string resp)
    {
        Debug.Log("response: " + resp);
        int status = int.Parse(resp);
        PlayerPrefs.SetInt("ReviewStatus", status);
    }
}

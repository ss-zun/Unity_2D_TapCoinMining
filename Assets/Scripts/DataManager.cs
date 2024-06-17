using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[Serializable]
public class ShopData
{
    public List<SlotData> SlotDatas = new List<SlotData>();
}

[Serializable]
public class SlotData
{
    public string Rcode;
    public string Name;
    public string Description;
    public int Price;
    public bool IsSold;
}

[Serializable]
public class UserInfo
{
    public int Amount;
    public float Speed;
    public int Coin;
}
public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public UserInfo UserInfo;
    public ShopData ShopDatas;

    string USERINFO_PATH = Application.dataPath + "/Resources/Data/UserInfo.json";
    string SHOPDATA_PATH = Application.dataPath + "/Resources/Data/SlotDatas.json";

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }
    private void LoadData()
    {
        if(!File.Exists(USERINFO_PATH))
        {
            UserInfo = new UserInfo();
            UserInfo.Amount = 1;
            UserInfo.Speed = 0.01f;
            UserInfo.Coin = 9;
        }
        else
        {
            var jsonUserInfoData = File.ReadAllText(USERINFO_PATH);
            UserInfo = JsonUtility.FromJson<UserInfo>(jsonUserInfoData);
        }

        if (!File.Exists(SHOPDATA_PATH))
        {
            Debug.LogWarning("아이템 데이터 없음");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        else
        {
            var jsonItemData = File.ReadAllText(SHOPDATA_PATH);
            ShopDatas = JsonUtility.FromJson<ShopData>(jsonItemData);
        }
    }

    public void SaveData()
    {
        var userData = JsonUtility.ToJson(UserInfo);
        File.WriteAllText(USERINFO_PATH, userData);
        Debug.Log("Data saved to " + USERINFO_PATH);

        var shopData = JsonUtility.ToJson(ShopDatas);
        File.WriteAllText(SHOPDATA_PATH, shopData);
        Debug.Log("Data saved to " + SHOPDATA_PATH);

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}

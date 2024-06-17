using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Shop : MonoBehaviour
{    
    public List<ItemSlot> Slots = new List<ItemSlot>();
    private ShopData shopDatas;

    private void Awake()
    {
        shopDatas = DataManager.instance.ShopDatas;       
    }

    private void Start()
    {
        DataManager.instance.OnSaveData += UpdateShopData;
        foreach (ItemSlot slot in Slots)
        {
            slot.OnBuyItem += UpdateShopData;
        }
        SetSlots();
        StartCoroutine(SaveDataPeriodically());
    }

    private void SetSlots()
    {
        for (int i = 0; i < shopDatas.SlotDatas.Count; i++)
        {
            if (Slots[i].Rcode == shopDatas.SlotDatas[i].Rcode)
            {
                Slots[i].SlotData = shopDatas.SlotDatas[i];
            }
        }
    }

    private IEnumerator SaveDataPeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(30.0f); // 30초마다 저장
            UpdateShopData();
            DataManager.instance.SaveData();
        }
    }

    public void UpdateShopData()
    {
        for (int i = 0; i < shopDatas.SlotDatas.Count; i++)
        {
            shopDatas.SlotDatas[i] = Slots[i].SlotData;   
        }
        DataManager.instance.ShopDatas = shopDatas;
    }
}

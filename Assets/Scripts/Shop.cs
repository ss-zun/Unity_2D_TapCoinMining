using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        SetSlots();
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
}

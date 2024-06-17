using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public SlotData SlotData;
    public Mining mininig;

    public string Rcode;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI Price;
    public bool IsSold;

    private void Start()
    {
        Name.text = SlotData.Name.ToString();
        Description.text = SlotData.Description.ToString();
        Price.text = SlotData.Price.ToString();
        IsSold = SlotData.IsSold;
    }

    public void BuyItem()
    {
        if (mininig.coin >= SlotData.Price && IsSold == false)
        {
            mininig.coin -= SlotData.Price;
            mininig.CoinTxt.text = mininig.coin.ToString();
            switch (Rcode)
            {
                case "ITE00001":
                    IsSold = true;
                    Price.text = "구매 완료";
                    mininig.IsAuto = true;
                    break;
                case "ITE00002":
                    if (mininig.speed >= 0.9f)
                    {
                        IsSold = true; 
                        Price.text = "Max 레벨";
                    }
                    else mininig.IncreaseSpeed();
                    break;
                case "ITE00003":
                    if (mininig.amount >= 100)
                    {
                        IsSold = true;
                        Price.text = "Max 레벨";
                    }
                    mininig.IncreaseAmount();
                    break;
            }   
        }
    }
}
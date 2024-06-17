using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class Mining : MonoBehaviour
{
    public static Mining instance;
    public TextMeshProUGUI CoinTxt;

    public int amount;
    public float speed;
    public int coin;
    public bool IsAuto;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializeUserData();
        UpdateCoinText();

        StartCoroutine(AutoClick());
    }

    private void InitializeUserData()
    {
        amount = DataManager.instance.UserInfo.Amount;
        speed = DataManager.instance.UserInfo.Speed;
        coin = DataManager.instance.UserInfo.Coin;
        IsAuto = DataManager.instance.UserInfo.IsAuto;
    }

    private IEnumerator AutoClick()
    {
        while (true)
        {
            if (IsAuto)
            {
                yield return new WaitForSeconds(1.0f - speed);
                IncreaseCoin();
            }
            else
            {
                yield return null;
            }
        }
    }

    public void IncreaseAmount()
    {
        amount += 1;
    }

    public void IncreaseSpeed()
    {
        speed += 0.01f;
    }

    public void IncreaseCoin()
    {
        coin += amount;
        UpdateCoinText();
    }

    public void UpdateCoinText()
    {
        CoinTxt.text = coin.ToString();
    }

    public void SaveData()
    {
        DataManager.instance.UserInfo.Amount = amount;
        DataManager.instance.UserInfo.Speed = speed;
        DataManager.instance.UserInfo.Coin = coin;
        DataManager.instance.UserInfo.IsAuto = IsAuto;
    }
}

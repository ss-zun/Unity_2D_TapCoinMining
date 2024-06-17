using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class Mining : MonoBehaviour
{
    public TextMeshProUGUI CoinTxt;

    public int amount;
    public float speed;
    public int coin;
    public bool IsAuto;

    private void Start()
    {
        InitializeUserData();
        UpdateCoinText();
        UnityEngine.Debug.Log(DataManager.instance.UserInfo.Speed);

        StartCoroutine(AutoClick());
    }

    private void InitializeUserData()
    {
        amount = DataManager.instance.UserInfo.Amount;
        speed = DataManager.instance.UserInfo.Speed;
        coin = DataManager.instance.UserInfo.Coin;
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

    private void UpdateCoinText()
    {
        CoinTxt.text = coin.ToString();
    }
}

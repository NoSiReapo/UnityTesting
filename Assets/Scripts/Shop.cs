using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private float Coin;
    [SerializeField] private Text TextCoin;

    private void Start()
    {
        Coin = 100;
        TextCoin.text = Coin.ToString();
    }
}

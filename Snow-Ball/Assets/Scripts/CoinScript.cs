using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coin;
    [SerializeField] private int goldMinus;
    public int coinAmount;

    private void Start()
    {
        coinAmount = 0;
    }

    void Update()
    {
        coin.SetText(coinAmount.ToString());
    }

    public void AddGold()
    {
        coinAmount += goldMinus;
    }


}

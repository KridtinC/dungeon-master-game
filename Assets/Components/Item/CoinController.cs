using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : ItemController
{
    private float value;

    private float copperCoinValue = 10;
    private float silverCoinValue = 50;
    private float goldCoinValue = 100;

    private void Start()
    {
        if (gameObject.name == "CopperCoins")
        {
            value = copperCoinValue;
        }
        else if (gameObject.name == "SilverCoins")
        {
            value = silverCoinValue;
        }
        else if(gameObject.name == "GoldCoins")
        {
            value = goldCoinValue;
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (pickup)
        {
            gameObject.SetActive(false);
        }
    }

    public float GetValue()
    {
        return value;
    }
    
}

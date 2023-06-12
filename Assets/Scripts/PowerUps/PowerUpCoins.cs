using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoins : PowerUpBase
{
    [Header("Candy Collector")]
    public float sizeAmount = 28;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.changeCoinCollectorSize(sizeAmount);
        PlayerController.Instance.SetPowerUpText("PowerUp CandyCollector");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.changeCoinCollectorSize(3);
        PlayerController.Instance.SetPowerUpText("");
    }    
}
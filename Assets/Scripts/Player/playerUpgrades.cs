using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerUpgrades : MonoBehaviour
{
    private playerStats playerStats;

    public void Start()
    {
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
    }
    public void PlayerUpgrade(int Upgrade)
    {
        if(Upgrade == 0)
        {
            playerStats.playerMaxDamage += 5;
            playerStats.playerMinDamage += 5;
        }
        else if (Upgrade == 1)
        {
            playerStats.playerMaxHealth += 5;
            playerStats.playerHealth += 5;

            if (playerStats.playerHealth > playerStats.playerMaxHealth)
            {
                playerStats.playerHealth = playerStats.playerMaxHealth;
            }
        }
        else if (Upgrade == 2)
        {
            playerStats.playerEnergy += 1;
        }

    }
}

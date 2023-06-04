using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerUpgrades : MonoBehaviour
{
    private playerStats playerStats;
    private MapEvent mapEvent;

    public void Start()
    {
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        mapEvent = GameObject.Find("Map").GetComponent<MapEvent>();
    }
    public void PlayerUpgrade(int Upgrade)
    {
        if(Upgrade == 0)
        {
            playerStats.playerMaxDamage += 5;
            playerStats.playerMinDamage += 5;
            SceneManager.LoadScene("MapScene");
            mapEvent.GetComponent<Canvas>().enabled = true;
        }
        else if (Upgrade == 1)
        {
            playerStats.playerMaxHealth += 5;
            playerStats.playerHealth += 5;

            if (playerStats.playerHealth > playerStats.playerMaxHealth)
            {
                playerStats.playerHealth = playerStats.playerMaxHealth;
            }

            SceneManager.LoadScene("MapScene");
            mapEvent.GetComponent<Canvas>().enabled = true;
        }
        else if (Upgrade == 2)
        {
            playerStats.playerMaxEnergy += 1;
            SceneManager.LoadScene("MapScene");
            mapEvent.GetComponent<Canvas>().enabled = true;
        }



    }
}

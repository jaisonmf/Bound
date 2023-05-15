using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerRest : MonoBehaviour
{
    private playerStats playerStats;

    public void Start()
    {
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
    }

    public void Rest(int Button)
    {
        if(Button == 1)
        {
            if(playerStats.playerHealth < (playerStats.playerMaxHealth * 0.8f))
            {
                playerStats.playerHealth += Mathf.RoundToInt(playerStats.playerMaxHealth * 0.2f);
            }
            else
            {
                playerStats.playerHealth = playerStats.playerMaxHealth;
            }

            SceneManager.LoadScene("MapScene");
            
        }
    }
}

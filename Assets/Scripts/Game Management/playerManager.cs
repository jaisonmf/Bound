using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    [SerializeField] private gameManager gameManager;
    [SerializeField] private enemyManager enemyManager;

    //playerStats
    private int playerMaxHealth = 100;
    public int playerHealth;
    [SerializeField] private int playerDamage;
    private int playerMinDamage;
    private int playerMaxDamage;

    [SerializeField] private Button action1;
    [SerializeField] private Button action2;
    [SerializeField] private Button action3;
    [SerializeField] private Button action4;

    private void Start()
    {
        action1.interactable = false;
        action2.interactable = false;
        action3.interactable = false;
        action4.interactable = false;
        playerHealth = playerMaxHealth;
    }
    public void PlayerTurn()
    {
        if(playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }


        
    }



    public void playerActions(int Button)
    {
        if(Button == 1)
        {

        }

        if(Button == 2)
        {

        }

        if(Button == 3)
        {

        }

        if(Button == 4)
        {
            gameManager.enemyTurn();
        }
    }


}

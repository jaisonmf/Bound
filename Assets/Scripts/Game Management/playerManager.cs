using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    [SerializeField] private gameManager gameManager;
    [SerializeField] private enemyManager enemyManager;

    //playerStats
    [SerializeField] private int playerMaxHealth = 100;
    public int playerHealth;
    [SerializeField] private int playerDamage;
    private int playerMinDamage;
    private int playerMaxDamage;

    //UI
    [SerializeField] private Button action1;
    [SerializeField] private Button action2;
    [SerializeField] private Button action3;
    [SerializeField] private Button action4;
    [SerializeField] private Slider playerHealthbar;


  
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

        if(playerHealth > 0)
        {
            action1.interactable = true;
            action2.interactable = true;
            action3.interactable = true;
            action4.interactable = true;
        }


        
    }



    public void playerActions(int Button)
    {
        if(Button == 1)
        {
            playerHealth -= 10;
            UpdateHealthBar(playerHealth, playerMaxHealth);
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
            action1.interactable = false;
            action2.interactable = false;
            action3.interactable = false;
            action4.interactable = false;
        }
    }


    public void UpdateHealthBar(float Currentvalue, float maxValue)
    {
        float percentageResult = Currentvalue / maxValue;
        playerHealthbar.value = percentageResult;
    }

}

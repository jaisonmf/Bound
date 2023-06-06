using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultAbility : MonoBehaviour
{
    public int energyCost;


    public void DefaultHeadAbility()
    {
        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();

        PlayerManager.MinDamage *= 2;
        PlayerManager.MaxDamage *= 2;
        PlayerManager.selecting = true;
        foreach (Transform child in PlayerManager.buttonSet2.transform)
        {
            if (child.name == "Back")
            {
                child.GetComponent<Button>().interactable = true;
            }
            else
            {
                child.GetComponent<Button>().interactable = false;
            }


        }
        playerStats.playerEnergy -= energyCost;
        PlayerManager.UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);
        playerStats.playerHealth -= 5;
        PlayerManager.UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);

    }

    public void DefaultBodyAbility()
    {
       playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
       playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        
        playerStats.playerHealth += 20;
        PlayerManager.UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);
        playerStats.playerEnergy -= energyCost;
        PlayerManager.UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);
    }

    public void DefaultLarmAbility()
    {
        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        enemyGenerator enemyGenerator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();

        foreach (GameObject enemy in enemyGenerator.spawnedEnemyList)
        {
            PlayerManager.MinDamage += 10;
            PlayerManager.MaxDamage += 10;
            PlayerManager.selecting = true;
            foreach (Transform child in PlayerManager.buttonSet2.transform)
            {
                if(child.name == "Back")
                {
                    child.GetComponent<Button>().interactable = true;
                }
                else
                {
                    child.GetComponent<Button>().interactable = false;
                }
               
               
            }
            playerStats.playerEnergy -= energyCost;
            PlayerManager.UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);
        }
        
    }

    public void DefaultRarmAbility()
    {
        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        enemyGenerator enemyGenerator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();

        PlayerManager.MinDamage = 60;
        PlayerManager.MaxDamage = 60;

        foreach (GameObject enemy in enemyGenerator.spawnedEnemyList)
        {
            if (enemy.activeSelf)
            {
                PlayerManager.MinDamage -= 10;
                PlayerManager.MaxDamage -= 10;
                PlayerManager.selecting = true;
                foreach (Transform child in PlayerManager.buttonSet2.transform)
                {
                    if (child.name == "Back")
                    {
                        child.GetComponent<Button>().interactable = true;
                    }
                    else
                    {
                        child.GetComponent<Button>().interactable = false;
                    }


                }
            }
            
        }

        
        playerStats.playerEnergy -= energyCost;
        PlayerManager.UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);

    }
    public void DefaultLlegAbility()
    {

        
        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
       


        playerStats.playerHealth -= 10;
        PlayerManager.UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);
        playerStats.playerEnergy++;
        PlayerManager.UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);

    }

    public void DefaultRlegbility()
    {
        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();

        PlayerManager.MinDamage = PlayerManager.MaxDamage;
        PlayerManager.selecting = true;
        foreach (Transform child in PlayerManager.buttonSet2.transform)
        {
            if (child.name == "Back")
            {
                child.GetComponent<Button>().interactable = true;
            }
            else
            {
                child.GetComponent<Button>().interactable = false;
            }


        }
        playerStats.playerEnergy -= energyCost;
        PlayerManager.UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);
    }
}
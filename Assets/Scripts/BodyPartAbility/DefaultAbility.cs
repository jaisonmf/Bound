using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultAbility : MonoBehaviour
{
    public int energyCost;
    public string ButtonEffect;

    public void DefaultHeadAbility()
    {
        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        enemyGenerator enemyGenerator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();

        playerStats.playerEnergy++;
    }

    public void DefaultBodyAbility()
    {
       playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
       playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        
        playerStats.playerHealth += 20;
        PlayerManager.UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);
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
            PlayerManager.special1.interactable = false;
            PlayerManager.special2.interactable = false;
            PlayerManager.special3.interactable = false;
            PlayerManager.special4.interactable = false;
            PlayerManager.special5.interactable = false;
            PlayerManager.special6.interactable = false;
            PlayerManager.specialExit.interactable = false;
            playerStats.playerEnergy -= energyCost;
            PlayerManager.UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);
        }
        
    }

    public void DefaultRarmAbility()
    {
        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        enemyGenerator enemyGenerator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();

        playerStats.playerEnergy++;
    }
    public void DefaultLlegAbility()
    {

        // playerStats.playerEnergy++;
        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        enemyGenerator enemyGenerator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();

        playerStats.playerEnergy++;
    }

    public void DefaultRlegbility()
    {

        //   playerStats.playerEnergy++;
        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        enemyGenerator enemyGenerator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();

        playerStats.playerEnergy++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAbility : MonoBehaviour
{
   

    public void DefaultHeadAbility()
    {
     
    }

    public void DefaultBodyAbility()
    {
       playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
       playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        enemyGenerator enemyGenerator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();
        playerStats.playerEnergy++;
    }

    public void DefaultLarmAbility()
    {
        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        enemyGenerator enemyGenerator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();

        playerStats.playerEnergy++;
        /*
        foreach (GameObject enemy in enemyGenerator.spawnedEnemyList)
        {
            playerStats.playerMaxDamage += 10;
            playerStats.playerMinDamage += 10;
            PlayerManager.selecting = true;
        }
        */
    }

    public void DefaultRarmAbility()
    {
        
    }
    public void DefaultLlegAbility()
    {
       
       // playerStats.playerEnergy++;
    }

    public void DefaultRlegbility()
    {
        
     //   playerStats.playerEnergy++;
    }
}

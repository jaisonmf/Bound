using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    [SerializeField] private enemyManager enemyManager;
    [SerializeField] private CSVReader cSVReader;
    [SerializeField] private playerStats playerStats;
    [SerializeField] private playerManager playerManager;

    [SerializeField] private GameObject enemy;




    public void wolfStat()
    {
        cSVReader = GameObject.Find("enemyCSV").GetComponent<CSVReader>();
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        playerManager = GameObject.Find("playerManager").GetComponent<playerManager>();

        enemy.GetComponent<enemyManager>().enemyMaxHealth = cSVReader.myEnemyList.enemy[2].maxHealth;
        enemy.GetComponent<enemyManager>().enemyMinHealth = cSVReader.myEnemyList.enemy[2].minHealth;

        enemy.GetComponent<enemyManager>().enemyMaxDamage = cSVReader.myEnemyList.enemy[2].maxDamage;
        enemy.GetComponent<enemyManager>().enemyMinDamage = cSVReader.myEnemyList.enemy[2].minDamage;
    }



    public void WolfAction()
    {
        int action = gameObject.GetComponent<enemyManager>().action;
        int damage = Random.Range(gameObject.GetComponent<enemyManager>().enemyMinDamage, gameObject.GetComponent<enemyManager>().enemyMaxDamage);

        if (action == 1 || action == 3)
        {
            playerStats.playerHealth -= damage;
        }
        else if (action == 2 || action == 4)
        {
            int flurry;

            flurry = Random.Range(1, 6);
       
            for (int i = 0; i < flurry; i++)
            {
     
                damage = Random.Range(gameObject.GetComponent<enemyManager>().enemyMinDamage, gameObject.GetComponent<enemyManager>().enemyMaxDamage);
                playerStats.playerHealth -= damage;
            
            }


        }

        playerManager.UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField] private enemyManager enemyManager;
    [SerializeField] private CSVReader cSVReader;
    [SerializeField] private playerStats playerStats;

    [SerializeField] private GameObject enemy;


    public void knightStat()
    {
        cSVReader = GameObject.Find("enemyCSV").GetComponent<CSVReader>();
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();

        enemy.GetComponent<enemyManager>().enemyMaxHealth = cSVReader.myEnemyList.enemy[1].maxHealth;
        enemy.GetComponent<enemyManager>().enemyMinHealth = cSVReader.myEnemyList.enemy[1].minHealth;

        enemy.GetComponent<enemyManager>().enemyMaxDamage = cSVReader.myEnemyList.enemy[1].maxDamage;
        enemy.GetComponent<enemyManager>().enemyMinDamage = cSVReader.myEnemyList.enemy[1].minDamage;

    }


    public void KnightAction()
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

            flurry = Random.Range(1, 3);
        
            for(int i = 0; i < flurry; i++)
            {
             
                damage = Random.Range(gameObject.GetComponent<enemyManager>().enemyMinDamage, gameObject.GetComponent<enemyManager>().enemyMaxDamage);
                playerStats.playerHealth -= damage;
            
            }
            
            
        }
    }

}

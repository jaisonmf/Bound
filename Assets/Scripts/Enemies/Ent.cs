using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ent : MonoBehaviour
{
    [SerializeField] private enemyManager enemyManager;
    [SerializeField] private CSVReader cSVReader;
    [SerializeField] private playerStats playerStats;

    [SerializeField] private GameObject enemy;




    public void entStat()
    {
        cSVReader = GameObject.Find("enemyCSV").GetComponent<CSVReader>();
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();

        enemy.GetComponent<enemyManager>().enemyMaxHealth = cSVReader.myEnemyList.enemy[3].maxHealth;
        enemy.GetComponent<enemyManager>().enemyMinHealth = cSVReader.myEnemyList.enemy[3].minHealth;

        enemy.GetComponent<enemyManager>().enemyMaxDamage = cSVReader.myEnemyList.enemy[3].maxDamage;
        enemy.GetComponent<enemyManager>().enemyMinDamage = cSVReader.myEnemyList.enemy[3].minDamage;
    }


    public void EntAction()
    {
        
        int action = gameObject.GetComponent<enemyManager>().action;


        if(action == 1)
        {
            int damage = Random.Range(gameObject.GetComponent<enemyManager>().enemyMinDamage, gameObject.GetComponent<enemyManager>().enemyMaxDamage);
            playerStats.playerHealth -= damage;
        }
        else if (action == 2)
        {
            gameObject.GetComponent<enemyManager>().enemyCurrentHealth += gameObject.GetComponent<enemyManager>().enemyCurrentHealth / 2;
            if(gameObject.GetComponent<enemyManager>().enemyCurrentHealth > gameObject.GetComponent<enemyManager>().enemyMaxHealth)
            {
                gameObject.GetComponent<enemyManager>().enemyCurrentHealth = gameObject.GetComponent<enemyManager>().enemyMaxHealth;
            }
        }
       

    }


}

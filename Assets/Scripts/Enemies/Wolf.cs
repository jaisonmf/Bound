using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    [SerializeField] private enemyManager enemyManager;
    [SerializeField] private CSVReader cSVReader;
    [SerializeField] private playerStats playerStats;

    [SerializeField] private GameObject enemy;




    public void wolfStat()
    {
        cSVReader = GameObject.Find("enemyCSV").GetComponent<CSVReader>();
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();

        enemy.GetComponent<enemyManager>().enemyMaxHealth = cSVReader.myEnemyList.enemy[2].maxHealth;
        enemy.GetComponent<enemyManager>().enemyMinHealth = cSVReader.myEnemyList.enemy[2].minHealth;

        enemy.GetComponent<enemyManager>().enemyMaxDamage = cSVReader.myEnemyList.enemy[2].maxDamage;
        enemy.GetComponent<enemyManager>().enemyMinDamage = cSVReader.myEnemyList.enemy[2].minDamage;
    }



    public void KnightAction()
    {
        int action = gameObject.GetComponent<enemyManager>().action;
        int damage = Random.Range(gameObject.GetComponent<enemyManager>().enemyMinDamage, gameObject.GetComponent<enemyManager>().enemyMaxDamage);

        if (action == 1)
        {
            playerStats.playerHealth -= damage;
        }
        else if (action == 2)
        {
            int flurry;

            flurry = Random.Range(1, 6);
            Debug.Log(flurry);
            for (int i = 0; i < flurry; i++)
            {
                Debug.Log("flurry");
                damage = Random.Range(gameObject.GetComponent<enemyManager>().enemyMinDamage, gameObject.GetComponent<enemyManager>().enemyMaxDamage);
                playerStats.playerHealth -= damage;
                Debug.Log(damage);
            }


        }
    }

}

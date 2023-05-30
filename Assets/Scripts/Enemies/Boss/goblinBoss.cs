using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinBoss : MonoBehaviour
{
    [SerializeField] private enemyManager enemyManager;
    [SerializeField] private CSVReader cSVReader;
    [SerializeField] private playerStats playerStats;

    [SerializeField] private GameObject boss;




    public void goblinBossStat()
    {
        cSVReader = GameObject.Find("bossCSV").GetComponent<CSVReader>();
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();

        boss.GetComponent<enemyManager>().enemyMaxHealth = cSVReader.myEnemyList.enemy[0].maxHealth;
        boss.GetComponent<enemyManager>().enemyMinHealth = cSVReader.myEnemyList.enemy[0].minHealth;

        boss.GetComponent<enemyManager>().enemyMaxDamage = cSVReader.myEnemyList.enemy[0].maxDamage;
        boss.GetComponent<enemyManager>().enemyMinDamage = cSVReader.myEnemyList.enemy[0].minDamage;
    }

    public void GoblinBossAction()
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

            flurry = Random.Range(1, 3);
            Debug.Log(flurry);
            for (int i = 0; i < flurry; i++)
            {
                Debug.Log("flurry");
                damage = Random.Range(gameObject.GetComponent<enemyManager>().enemyMinDamage, gameObject.GetComponent<enemyManager>().enemyMaxDamage);
                playerStats.playerHealth -= damage;
                Debug.Log(damage);
            }


        }
        else if (action == 3)
        {
            enemyGenerator generator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>(); 
            for(int i = 0; i < generator.spawnedEnemyList.Count; i++)
            {
                gameObject.GetComponent<enemyManager>().enemyCurrentHealth += 20;
            }
        }
        
    }
}

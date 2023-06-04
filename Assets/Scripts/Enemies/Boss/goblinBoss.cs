using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goblinBoss : MonoBehaviour
{
    [SerializeField] private enemyManager enemyManager;
    [SerializeField] private CSVReader cSVReader;
    [SerializeField] private playerStats playerStats;

    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject Summon;
    [SerializeField] private GameObject SummonLocation1;
    [SerializeField] private GameObject SummonLocation2;




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


        if(gameObject.GetComponent<enemyManager>().enemyCurrentHealth > 0)
        {
            if (action == 1 || action == 4)
            {
                playerStats.playerHealth -= damage;
            }
            else if (action == 2)
            {
                int flurry;

                flurry = Random.Range(1, 3);
               
                for (int i = 0; i < flurry; i++)
                {
                    Debug.Log("flurry");   damage = Random.Range(gameObject.GetComponent<enemyManager>().enemyMinDamage, gameObject.GetComponent<enemyManager>().enemyMaxDamage);
                    playerStats.playerHealth -= damage;
            
                }


            }
            else if (action == 3)
            {
                int amountHealed = 0;
                enemyGenerator generator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();
               foreach(GameObject enemy in generator.spawnedEnemyList)
                {
                    if (enemy.activeSelf)
                    {
                        amountHealed += 20;
                    }
                }
                gameObject.GetComponent<enemyManager>().enemyCurrentHealth += amountHealed;

                if (gameObject.GetComponent<enemyManager>().enemyCurrentHealth > gameObject.GetComponent<enemyManager>().enemyMaxHealth)
                {
                    gameObject.GetComponent<enemyManager>().enemyCurrentHealth = gameObject.GetComponent<enemyManager>().enemyMaxHealth;
                }
            }
           
            
        }
        else
        {
            SceneManager.LoadScene("EndZone");
        }
       
        
    }
}

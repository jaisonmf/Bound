using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ent : MonoBehaviour
{
    [SerializeField] private enemyManager enemyManager;
    [SerializeField] private CSVReader cSVReader;
    [SerializeField] private playerStats playerStats;
    [SerializeField] private playerManager playerManager;

    [SerializeField] private GameObject enemy;




    public void entStat()
    {
        cSVReader = GameObject.Find("enemyCSV").GetComponent<CSVReader>();
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        playerManager = GameObject.Find("playerManager").GetComponent<playerManager>();

        enemy.GetComponent<enemyManager>().enemyMaxHealth = cSVReader.myEnemyList.enemy[3].maxHealth;
        enemy.GetComponent<enemyManager>().enemyMinHealth = cSVReader.myEnemyList.enemy[3].minHealth;

        enemy.GetComponent<enemyManager>().enemyMaxDamage = cSVReader.myEnemyList.enemy[3].maxDamage;
        enemy.GetComponent<enemyManager>().enemyMinDamage = cSVReader.myEnemyList.enemy[3].minDamage;
    }


    public void EntAction()
    {
        
        int action = gameObject.GetComponent<enemyManager>().action;
        enemyGenerator enemyGenerator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();

        if(action == 1 || action == 3)
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
        
        else if (action == 4)
        {
            StatusEffectController StatusEffectController = gameObject.GetComponent<StatusEffectController>();
            enemy.GetComponent<enemyManager>().GetComponent<StatusEffectController>().AddTaunt();

            if (StatusEffectController.tauntStacks != 0)
            {
                foreach (GameObject enemy in enemyGenerator.spawnedEnemyList)
                {
                    if (enemy != gameObject && enemy.GetComponent<StatusEffectController>().tauntStacks == 0)
                    {
                        enemy.GetComponentInChildren<Button>().interactable = false;
                        StatusEffectController.tauntStacks--;
                    }

                }
            }
        }
       
        

        playerManager.UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);
    }


}

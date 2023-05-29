using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    [SerializeField] private enemyManager enemyManager;
    [SerializeField] private CSVReader cSVReader;
    [SerializeField] private playerStats playerStats;

    [SerializeField] private GameObject enemy;


  

    public void goblinStat()
    {
        cSVReader = GameObject.Find("enemyCSV").GetComponent<CSVReader>();
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();

        enemy.GetComponent<enemyManager>().enemyMaxHealth = cSVReader.myEnemyList.enemy[0].maxHealth;
        enemy.GetComponent<enemyManager>().enemyMinHealth = cSVReader.myEnemyList.enemy[0].minHealth;

        enemy.GetComponent<enemyManager>().enemyMaxDamage = cSVReader.myEnemyList.enemy[0].maxDamage;
        enemy.GetComponent<enemyManager>().enemyMinDamage = cSVReader.myEnemyList.enemy[0].minDamage;
    }





}

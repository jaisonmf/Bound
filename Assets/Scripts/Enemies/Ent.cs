using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ent : MonoBehaviour
{
    [SerializeField] private enemyManager enemyManager;
    [SerializeField] private CSVReader cSVReader;
    [SerializeField] private playerManager playerManager;

    [SerializeField] private GameObject enemy;




    public void entStat()
    {
        cSVReader = GameObject.Find("enemyCSV").GetComponent<CSVReader>();

        enemy.GetComponent<enemyManager>().enemyMaxHealth = cSVReader.myEnemyList.enemy[0].maxHealth;
        enemy.GetComponent<enemyManager>().enemyMinHealth = cSVReader.myEnemyList.enemy[0].minHealth;

        enemy.GetComponent<enemyManager>().enemyMaxDamage = cSVReader.myEnemyList.enemy[0].maxDamage;
        enemy.GetComponent<enemyManager>().enemyMinDamage = cSVReader.myEnemyList.enemy[0].minDamage;
    }

}

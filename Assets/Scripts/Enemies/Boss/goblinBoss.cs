using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinBoss : MonoBehaviour
{
    [SerializeField] private enemyManager enemyManager;
    [SerializeField] private CSVReader cSVReader;
    [SerializeField] private playerManager playerManager;

    [SerializeField] private GameObject boss;




    public void goblinBossStat()
    {
        cSVReader = GameObject.Find("bossCSV").GetComponent<CSVReader>();

        boss.GetComponent<enemyManager>().enemyMaxHealth = cSVReader.myEnemyList.enemy[0].maxHealth;
        boss.GetComponent<enemyManager>().enemyMinHealth = cSVReader.myEnemyList.enemy[0].minHealth;

        boss.GetComponent<enemyManager>().enemyMaxDamage = cSVReader.myEnemyList.enemy[0].maxDamage;
        boss.GetComponent<enemyManager>().enemyMinDamage = cSVReader.myEnemyList.enemy[0].minDamage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] private playerManager playerManager;
    [SerializeField] private enemyManager enemyManager;
    [SerializeField] private enemyGenerator enemyGenerator;
    [SerializeField] private playerStats playerStats;


    private void Start()
    {
        playerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();

        playerTurn();

    }

    public void enemyGeneration()
    {
        enemyGenerator.Generation();

    }

    public void playerTurn()
    {
        playerManager.PlayerTurn();
    }

    public void enemyTurn()
    {

            StartCoroutine(takeTurn());

    }

    IEnumerator takeTurn()
    {
        foreach (GameObject enemy in enemyGenerator.spawnedEnemyList)
        {
            if(enemy.activeSelf == true)
            {
                enemy.GetComponent<enemyManager>().turnArrow.SetActive(true);
                enemy.GetComponent<enemyManager>().EnemyTurn();

                playerManager.UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);
                enemy.GetComponent<enemyManager>().UpdateEnemyHealthBar(enemy.GetComponent<enemyManager>().enemyCurrentHealth, enemy.GetComponent<enemyManager>().enemyMaxHealth);

                yield return new WaitForSeconds(1.5f);



                enemy.GetComponent<enemyManager>().turnArrow.SetActive(false);
                enemy.GetComponent<enemyManager>().enabled = false;
                yield return new WaitForSeconds(1f);

            }

        }
       
        playerTurn();
    }

}

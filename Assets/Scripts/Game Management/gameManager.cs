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
            //enemy.GetComponent<enemyManager>().enabled = true; // Enable enemy script
            enemy.GetComponent<enemyManager>().turnArrow.SetActive(true);

            yield return new WaitForSeconds(1);

            enemy.GetComponent<enemyManager>().EnemyTurn();

            enemy.GetComponent<enemyManager>().turnArrow.SetActive(false);
           // enemy.GetComponent<enemyManager>().enabled = false; // Disable enemy script again
            playerManager.UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);

        }
    }

}

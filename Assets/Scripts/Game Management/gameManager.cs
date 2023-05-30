using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] private playerManager playerManager;
    [SerializeField] private enemyManager enemyManager;
    [SerializeField] private enemyGenerator enemyGenerator;


    private void Start()
    {
        playerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        
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

        foreach (GameObject enemy in enemyGenerator.spawnedEnemyList)
        {
            StartCoroutine(takeTurn(enemy));
        }
    }

    IEnumerator takeTurn(GameObject enemy)
    {
        enemy.GetComponent<enemyManager>().turnArrow.SetActive(true);
        yield return new WaitForSeconds(3);
        enemy.GetComponent<enemyManager>().EnemyTurn();
        Debug.Log("attack");
        yield return new WaitForSeconds(1);
        enemy.GetComponent<enemyManager>().turnArrow.SetActive(false);
    }

}

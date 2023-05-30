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

        for(int i = 0; i < enemyGenerator.spawnedEnemyList.Count; i++)
        {
            enemyGenerator.spawnedEnemyList[i].GetComponent<enemyManager>().EnemyTurn();
            
        }
    }



}

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
        enemyGeneration();
        //playerTurn();

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
        enemyManager.EnemyTurn();
    }



}

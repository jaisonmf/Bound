using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] private playerManager playerManager;
    [SerializeField] private enemyManager enemyManager;



    private void Start()
    {
        playerTurn();

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

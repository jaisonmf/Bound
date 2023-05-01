using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    [SerializeField] private gameManager gameManager;
    [SerializeField] private enemyManager enemyManager;

    //playerStats
    private int playerMaxHealth = 100;
    public int playerHealth;
    [SerializeField] private int playerDamage;
    private int playerMinDamage;
    private int playerMaxDamage;


    public void PlayerTurn()
    {

    }


}

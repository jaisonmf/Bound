using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    [SerializeField] private gameManager gameManager;
    [SerializeField] private playerManager playerManager;

    //enemyStats
    private int enemyMaxHealth;
    private int enemyMinHealth;
    public int enemyHealth;
    [SerializeField] private int enemyDamage;
    private int enemyMinDamage;
    private int enemyMaxDamage;


    public void EnemyTurn()
    {

    }

}

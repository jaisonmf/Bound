using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    [SerializeField] private gameManager gameManager;
    [SerializeField] private playerManager playerManager;


    //enemyStats
    private int enemyMaxHealth = 100;
    private int enemyMinHealth = 100;
    public int enemyHealth = 100;
    public int enemyCurrentHealth = 100;
    [SerializeField] private int enemyDamage;
    private int enemyMinDamage;
    private int enemyMaxDamage;
    private int action;


    //enemyUI
    [SerializeField] private Slider enemyHealthBar;
    private bool isCoroutineOn;

 


    public void EnemyTurn()
    {
        if (enemyCurrentHealth > 0)
        {
            if (enemyCurrentHealth > enemyHealth)
            {
                enemyCurrentHealth = enemyHealth;
            }


        }
        Debug.Log("hur hur hur hur hur hur hur hur hur hur");
        StartCoroutine(EnemyAction());

    }


    IEnumerator EnemyAction()
    {
        yield return new WaitForSeconds(3);

        action = Random.Range(1, 3);

        if (action == 1)
        {
            enemyDamage = Random.Range(enemyMinDamage, enemyMaxDamage);

            playerManager.playerHealth -= enemyDamage;
            playerManager.UpdateHealthBar(playerManager.playerHealth, playerManager.playerMaxHealth);
            gameManager.playerTurn();
        }
        else if (action == 2)
        {
            enemyDamage = Random.Range(enemyMinDamage, enemyMaxDamage);

            playerManager.playerHealth -= enemyDamage;
            playerManager.UpdateHealthBar(playerManager.playerHealth, playerManager.playerMaxHealth);
            gameManager.playerTurn();
        }
        else
        {
            enemyDamage = Random.Range(enemyMinDamage, enemyMaxDamage);

            playerManager.playerHealth -= enemyDamage;
            playerManager.UpdateHealthBar(playerManager.playerHealth, playerManager.playerMaxHealth);
            gameManager.playerTurn();
        }


    }



    public void UpdateHealthBar(float Currentvalue, float maxValue)
    {
        float percentageResult = Currentvalue / maxValue;
        enemyHealthBar.value = percentageResult;
    }

}



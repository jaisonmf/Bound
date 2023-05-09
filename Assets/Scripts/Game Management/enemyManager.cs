using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyManager : MonoBehaviour
{
    [SerializeField] private gameManager gameManager;
    [SerializeField] private playerStats playerStats;
    [SerializeField] private playerManager playerManager;


    //enemyStats
    public int enemyMinHealth;
    public int enemyMaxHealth;
    public int enemyCurrentHealth;
    [SerializeField] private int enemyDamage;
    [HideInInspector] public int enemyMinDamage;
    [HideInInspector] public int enemyMaxDamage;
    private int action;
    public bool alive;


    //enemyUI
    public Slider enemyHealthBar;
    private bool isCoroutineOn = false;
    public int enemyCount;



    public void Start()
    {
        alive = true;
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        playerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
    }

    public void EnemyTurn()
    {
        if (enemyCurrentHealth > 0)
        {
            if (enemyCurrentHealth > enemyMaxHealth)
            {
                enemyCurrentHealth = enemyMaxHealth;
            }


        }
        if(alive == true)
        {
            StartCoroutine(EnemyAction(3));
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        

    }


    IEnumerator EnemyAction(float time)
    {
 
        if (isCoroutineOn)
            yield break;

        isCoroutineOn = true;

        yield return new WaitForSeconds(time);

        action = Random.Range(1, 3);
        action = 1;
        if (action == 1)
        {
            
            enemyDamage = Random.Range(enemyMinDamage, enemyMaxDamage);

            playerStats.playerHealth -= enemyDamage;
            playerManager.UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);
        }
        else if (action == 2)
        {
            Debug.Log("i did a thing");
        }
        else
        {
            Debug.Log("i did another thing");
        }

        gameManager.playerTurn();
        isCoroutineOn = false;
    }



    public void UpdateEnemyHealthBar(float Currentvalue, float maxValue)
    {
        float percentageResult = Currentvalue / maxValue;
        enemyHealthBar.value = percentageResult;

    }

}


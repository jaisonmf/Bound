using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyManager : MonoBehaviour
{
    [SerializeField] private gameManager gameManager;
    [SerializeField] private playerManager playerManager;


    //enemyStats
    private float enemyMaxHealth = 100;
    private float enemyMinHealth = 100;
    public float enemyHealth = 100;
    public float enemyCurrentHealth = 100;
    [SerializeField] private float enemyDamage;
    private float enemyMinDamage = 20;
    private float enemyMaxDamage = 20;
    private int action;


    //enemyUI
    [SerializeField] private Slider enemyHealthBar;
    private bool isCoroutineOn = false;
    [HideInInspector] public int enemyCount;



    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
        playerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        enemyCurrentHealth = enemyHealth;
    }

    public void EnemyTurn()
    {
        if (enemyCurrentHealth > 0)
        {
            if (enemyCurrentHealth > enemyHealth)
            {
                enemyCurrentHealth = enemyHealth;
            }


        }
        
        StartCoroutine(EnemyAction(3));

    }


    IEnumerator EnemyAction(float time)
    {
 
        if (isCoroutineOn)
            yield break;

        isCoroutineOn = true;

        yield return new WaitForSeconds(time);

        action = Random.Range(1, 3);
        
        if (action == 1)
        {
            
            enemyDamage = Random.Range(enemyMinDamage, enemyMaxDamage);
            
            playerManager.playerHealth -= enemyDamage;
            Debug.Log(playerManager.playerHealth);
            playerManager.UpdateHealthBar(playerManager.playerHealth, playerManager.playerMaxHealth);
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


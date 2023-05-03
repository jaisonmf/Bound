using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    [SerializeField] private gameManager gameManager;
    [SerializeField] private enemyManager enemyManager;
    [SerializeField] private enemyGenerator enemyGenerator;

    //playerStats
    public int playerMaxHealth = 100;
    public int playerHealth;
    [SerializeField] private int playerDamage;
    private int playerMinDamage = 5;
    private int playerMaxDamage = 10;

    //UI
    [SerializeField] private Button action1;
    [SerializeField] private Button action2;
    [SerializeField] private Button action3;
    [SerializeField] private Button action4;
    [SerializeField] private Slider playerHealthbar;
    public bool selecting = false;

    private bool isCoroutineOn;
    [SerializeField] private GameObject UI;

    public void Map()
    {
        action1.interactable = false;
        action2.interactable = false;
        action3.interactable = false;
        action4.interactable = false;
        UI.SetActive(false);

    }

  
    private void Start()
    {
        action1.interactable = false;
        action2.interactable = false;
        action3.interactable = false;
        action4.interactable = false;

        playerHealth = playerMaxHealth;
        UpdateHealthBar(playerHealth, playerMaxHealth);

    }
    public void PlayerTurn()
    {
        if(playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }

        if(playerHealth > 0)
        {
            action1.interactable = true;
            action2.interactable = true;
            action3.interactable = true;
            action4.interactable = true;
        }


        
    }



    public void playerActions(int Button)
    {
        if(Button == 1)
        {
            selecting = true;
            action1.interactable = false; 
            action2.interactable = false;
            action3.interactable = false;
            action4.interactable = false;
        }

        if(Button == 2)
        {

        }

        if(Button == 3)
        {
            playerHealth -= 10;
            UpdateHealthBar(playerHealth, playerMaxHealth);
        }

        if(Button == 4)
        {
            gameManager.enemyTurn();
            action1.interactable = false;
            action2.interactable = false;
            action3.interactable = false;
            action4.interactable = false;
        }
    }

    public void PlayerAttack(int listIndex)
    {
        GameObject enemy = enemyGenerator.spawnedEnemyList[listIndex];
        Debug.Log(enemy);
        playerDamage = Random.Range(playerMinDamage, playerMaxDamage);
        enemy.GetComponent<enemyManager>().enemyCurrentHealth -= playerDamage;
        enemy.GetComponent<enemyManager>().UpdateEnemyHealthBar(enemy.GetComponent<enemyManager>().enemyCurrentHealth, enemy.GetComponent<enemyManager>().enemyMaxHealth);


        selecting = false;
        action1.interactable = true;
        action2.interactable = true;
        action3.interactable = true;
        action4.interactable = true;
        StartCoroutine(Delay(0.5f));

        IEnumerator Delay(float time)
        {
            if (isCoroutineOn)
                yield break;

            isCoroutineOn = true;
            yield return new WaitForSeconds(time);

            if (enemy.GetComponent<enemyManager>().enemyCurrentHealth <= 0)
            {
                enemy.GetComponent<enemyManager>().alive = false;
                
                if(enemy.GetComponent<enemyManager>().alive == false)
                {
                    enemy.GetComponentInChildren<Image>().enabled = false;
                    //enemy.GetComponentInChildren<Slider>().image.enabled = false;
                    enemy.GetComponentInChildren<Button>().image.enabled = false;
                }
                
            }
        }

        isCoroutineOn = false;


        bool alive = false;
        for(int i = 0; i <enemyGenerator.spawnedEnemyList.Count; i++)
        {
            if(enemyGenerator.spawnedEnemyList[i].GetComponent<enemyManager>().enemyCurrentHealth > 0)
            {
                alive = true;
            }
        }

        if(alive == false)
        {
            for (int i = 0; i < enemyGenerator.spawnedEnemyList.Count; i++)
            {
                if (enemyGenerator.spawnedEnemyList[i].GetComponent<enemyManager>().enemyCurrentHealth < 0)
                {
                    //Destroy(enemyGenerator.spawnedEnemyList[i]);
                }
            }


        }

    }





    public void UpdateHealthBar(float Currentvalue, float maxValue)
    {
        float percentageResult = Currentvalue / maxValue;
        playerHealthbar.value = percentageResult;
    }

}

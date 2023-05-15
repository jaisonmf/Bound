using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerManager : MonoBehaviour
{
    [SerializeField] private gameManager gameManager;
    [SerializeField] private enemyManager enemyManager;
    [SerializeField] private enemyGenerator enemyGenerator;
    [SerializeField] private playerStats playerStats;


    //UI
    [SerializeField] private Button action1;
    [SerializeField] private Button action2;
    [SerializeField] private Button action3;
    [SerializeField] private Button action4;
    [SerializeField] private Slider playerHealthbar;
    [SerializeField] private Slider playerEnergybar;
    
    public bool selecting = false;
    private int damage;
    private bool isCoroutineOn;
    [SerializeField] private GameObject UI;


 
    private void Start()
    {
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        /*
        action1.interactable = false;
        action2.interactable = false;
        action3.interactable = false;
        action4.interactable = false;
        */
        UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);
        playerStats.playerEnergy = playerStats.playerMaxEnergy;
        UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);


    }
    public void PlayerTurn()
    {
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
     
        if (playerStats.playerHealth > playerStats.playerMaxHealth)
        {
            playerStats.playerHealth = playerStats.playerMaxHealth;
            UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);
            
        }

        if(playerStats.playerHealth > 0)
        {
            action1.interactable = true;
            action2.interactable = true;
            action3.interactable = true;
            action4.interactable = true;
            playerStats.playerEnergy = playerStats.playerMaxEnergy;
            UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);
        }
        else
        {
            //Lose nerd
        }


        
    }



    public void playerActions(int Button)
    {
        if(Button == 1 && playerStats.playerEnergy >= 1)
        {
            selecting = true;
            action1.interactable = false; 
            action2.interactable = false;
            action3.interactable = false;
            action4.interactable = false;
            playerStats.playerEnergy -= 1;
            UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);
        }

        if(Button == 2)
        {
            gameManager.enemyGeneration();
        }

        if(Button == 3)
        {

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
        //Player attacks individual enemy so it doesnt hit all
        GameObject enemy = enemyGenerator.spawnedEnemyList[listIndex];
        bool alive = false;
        damage = Random.Range(playerStats.playerMinDamage, playerStats.playerMaxDamage);
        enemy.GetComponent<enemyManager>().enemyCurrentHealth -= damage;
        enemy.GetComponent<enemyManager>().UpdateEnemyHealthBar(enemy.GetComponent<enemyManager>().enemyCurrentHealth, enemy.GetComponent<enemyManager>().enemyMaxHealth);


        selecting = false;
        action1.interactable = true;
        action2.interactable = true;
        action3.interactable = true;
        action4.interactable = true;
        StartCoroutine(Delay(0.5f));

        //Delay between attack and continue turn
        IEnumerator Delay(float time)
        {
            if (isCoroutineOn)
                yield break;

            isCoroutineOn = true;
            yield return new WaitForSeconds(time);

            if (enemy.GetComponent<enemyManager>().enemyCurrentHealth <= 0 && enemy == alive)
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


        //If all enemies are considered 'alive', keep going
        for(int i = 0; i <enemyGenerator.spawnedEnemyList.Count; i++)
        {
            if(enemyGenerator.spawnedEnemyList[i].GetComponent<enemyManager>().enemyCurrentHealth > 0)
            {
                alive = true;
            }
        }
        //If all enemies are dead, win the battle
        if(alive == false)
        {
            for (int i = 0; i < enemyGenerator.spawnedEnemyList.Count; i++)
            {
                if (enemyGenerator.spawnedEnemyList[i].GetComponent<enemyManager>().enemyCurrentHealth < 0)
                {
                    Destroy(enemyGenerator.spawnedEnemyList[i]);
                    enemyGenerator.spawnedEnemyList.Clear();
                    SceneManager.LoadScene("Win");
                    action1.interactable = false;
                    action2.interactable = false;
                    action3.interactable = false;
                    action4.interactable = false;

                }
            }


        }

    }




    
    public void UpdateHealthBar(float Currentvalue, float maxValue)
    {
        float percentageResult = Currentvalue / maxValue;
        playerHealthbar.value = percentageResult;
    }
    public void UpdateEnergyBar(float Currentvalue, float maxValue)
    {
        float percentageResult = Currentvalue / maxValue;
        playerEnergybar.value = percentageResult;
    }

}

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
    private StatusEffectController statusEffectController;


    //UI
    [SerializeField] private Button action1;
    [SerializeField] private Button action2;
    [SerializeField] private Button action3;
    [SerializeField] private Button action4;
    [SerializeField] private Slider playerHealthbar;
    [SerializeField] private Slider playerEnergybar;

    [SerializeField] private GameObject buttonSet1;
    [SerializeField] private GameObject buttonSet2;


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
        statusEffectController = GetComponent<StatusEffectController>();
     
        //player doesnt go over max health
        if (playerStats.playerHealth > playerStats.playerMaxHealth)
        {
            playerStats.playerHealth = playerStats.playerMaxHealth;
            UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);
            
        }
        //player is above 0 health and can take their turn
        if(playerStats.playerHealth != 0)
        {
            action1.interactable = true;
            action2.interactable = true;
            action3.interactable = true;
            action4.interactable = true;
            statusEffectController.EffectUpdate();
            UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);
            playerStats.playerEnergy = playerStats.playerMaxEnergy;
            UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);
            
        }
       
        //player is dead
        else if (playerStats.playerHealth <= 0)
        {
            SceneManager.LoadScene("Lose");
        }


        
    }


    public void CheckEnergy()
    {
         if (playerStats.playerEnergy == 0)
        {
            selecting = false;
            action1.interactable = false;
            action2.interactable = false;
            action3.interactable = false;
            action4.interactable = false;
            gameManager.enemyTurn();

        }
    }
    //Default Menu
    public void playerActions(int Button)
    {
        //Attack
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

        //Special Attacks
        if(Button == 2)
        {
            buttonSet2.SetActive(true);
            buttonSet1.SetActive(false);
            
            

        }
        //idk
        if (Button == 3)
        {
            
        }
        //end turn
        if (Button == 4)
        {
            gameManager.enemyTurn();
            action1.interactable = false;
            action2.interactable = false;
            action3.interactable = false;
            action4.interactable = false;

        }
    }

    //Special Menu
    public void Special(int Button)
    {
        GameObject bodyPart;

        //Head
        if(Button == 1)
        {
            bodyPart = playerStats.GetComponent<playerStats>().PrefabequippedHead.gameObject;

            GameObject targetObject = bodyPart.GetComponent<ItemScript>().gameObject;

            Component targetScript = targetObject.GetComponent(bodyPart.GetComponent<ItemScript>().AbilityScriptName);


            System.Type targetType = System.Type.GetType(bodyPart.GetComponent<ItemScript>().AbilityScriptName);
            System.Reflection.MethodInfo targetFunction = targetType.GetMethod(bodyPart.GetComponent<ItemScript>().AbilityScriptFunction);

            if (targetFunction != null)
            {
                targetFunction.Invoke(targetScript, null);
            }
        }
        //Body
        if (Button == 2)
        {
            bodyPart = playerStats.GetComponent<playerStats>().PrefabequippedBody.gameObject;

            GameObject targetObject = bodyPart.GetComponent<ItemScript>().gameObject;
            
            Component targetScript = targetObject.GetComponent(bodyPart.GetComponent<ItemScript>().AbilityScriptName);


            System.Type targetType = System.Type.GetType(bodyPart.GetComponent<ItemScript>().AbilityScriptName);
            System.Reflection.MethodInfo targetFunction = targetType.GetMethod(bodyPart.GetComponent<ItemScript>().AbilityScriptFunction);

            if (targetFunction != null)
            {
                targetFunction.Invoke(targetScript, null);
            }

        }
        //Larm
        if (Button == 3)
        {
            bodyPart = playerStats.GetComponent<playerStats>().PrefabequippedLeftArm.gameObject;

            GameObject targetObject = bodyPart.GetComponent<ItemScript>().gameObject;

            Debug.Log(bodyPart);
            Component targetScript = targetObject.GetComponent(bodyPart.GetComponent<ItemScript>().AbilityScriptName);


            System.Type targetType = System.Type.GetType(bodyPart.GetComponent<ItemScript>().AbilityScriptName);
            System.Reflection.MethodInfo targetFunction = targetType.GetMethod(bodyPart.GetComponent<ItemScript>().AbilityScriptFunction);

            if (targetFunction != null)
            {
                
                Debug.Log(targetScript);
    
                targetFunction.Invoke(targetScript, null);
            }
        }
        //Rarm
        if (Button == 4)
        {
            bodyPart = playerStats.GetComponent<playerStats>().PrefabequippedRightArm.gameObject;

            GameObject targetObject = bodyPart.GetComponent<ItemScript>().gameObject;

            Component targetScript = targetObject.GetComponent(bodyPart.GetComponent<ItemScript>().AbilityScriptName);


            System.Type targetType = System.Type.GetType(bodyPart.GetComponent<ItemScript>().AbilityScriptName);
            System.Reflection.MethodInfo targetFunction = targetType.GetMethod(bodyPart.GetComponent<ItemScript>().AbilityScriptFunction);

            if (targetFunction != null)
            {
                targetFunction.Invoke(targetScript, null);
            }
        }
        //Lleg
        if (Button == 5)
        {
            bodyPart = playerStats.GetComponent<playerStats>().PrefabequippedLeftLeg.gameObject;

            GameObject targetObject = bodyPart.GetComponent<ItemScript>().gameObject;

            Component targetScript = targetObject.GetComponent(bodyPart.GetComponent<ItemScript>().AbilityScriptName);


            System.Type targetType = System.Type.GetType(bodyPart.GetComponent<ItemScript>().AbilityScriptName);
            System.Reflection.MethodInfo targetFunction = targetType.GetMethod(bodyPart.GetComponent<ItemScript>().AbilityScriptFunction);

            if (targetFunction != null)
            {
                targetFunction.Invoke(targetScript, null);
            }
        }
        //Rleg
        if (Button == 6)
        {
            bodyPart = playerStats.GetComponent<playerStats>().PrefabequippedRightLeg.gameObject;

            GameObject targetObject = bodyPart.GetComponent<ItemScript>().gameObject;

            Component targetScript = targetObject.GetComponent(bodyPart.GetComponent<ItemScript>().AbilityScriptName);


            System.Type targetType = System.Type.GetType(bodyPart.GetComponent<ItemScript>().AbilityScriptName);
            System.Reflection.MethodInfo targetFunction = targetType.GetMethod(bodyPart.GetComponent<ItemScript>().AbilityScriptFunction);

            if (targetFunction != null)
            {
                targetFunction.Invoke(targetScript, null);
            }

        }
        //Exit
        if (Button == 7)
        {
            buttonSet1.SetActive(true);
            buttonSet2.SetActive(false);
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
        CheckEnergy();

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

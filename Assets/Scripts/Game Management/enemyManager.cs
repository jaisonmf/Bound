using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class enemyManager : MonoBehaviour
{
    [SerializeField] private gameManager gameManager;
    [SerializeField] private playerStats playerStats;
    [SerializeField] private playerManager playerManager;
    private hoverController hoverController;
    private enemyGenerator enemyGenerator;
    private StatusEffectController statusEffectController;

    //Enemy Script
    public string EnemyFunctionScript;
    public string EnemyFunctionName;

    //enemyStats
    public int enemyMinHealth;
    public int enemyMaxHealth;
    public int enemyCurrentHealth;
    [SerializeField] private int enemyDamage;
    [HideInInspector] public int enemyMinDamage;
    [HideInInspector] public int enemyMaxDamage;
    [HideInInspector] public int action;
    public bool alive;


    //enemyUI
    public Slider enemyHealthBar;
    private bool isCoroutineOn = false;
    public int enemyCount;
    public GameObject turnArrow;

    //Status Effects
    public List<GameObject> statusEffect;


    public void Start()
    {
        //Find all scripts
        alive = true;
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        playerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        hoverController = GameObject.Find("EventSystem").GetComponent<hoverController>();
        enemyGenerator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();
        statusEffectController = gameObject.GetComponent<StatusEffectController>();



    }

    public void EnemyTurn()
    {
        
        //Check if enemy health is more than 0
        if (enemyCurrentHealth > 0)
        {
            //Makes sure health is not higher than max health
            if (enemyCurrentHealth > enemyMaxHealth)
            {
                enemyCurrentHealth = enemyMaxHealth;
            }


        }
        if(alive == true)
        {


            TauntCheck();
            StartCoroutine(EnemyAction(3));

            
        }
        else
        {
            gameObject.SetActive(false);
            statusEffectController.tauntStacks = 0;
            TauntCheck();
        }
        
        

    }

    public void TauntCheck()
    {
        if (statusEffectController.tauntStacks != 0)
        {
            statusEffectController.tauntStacks--;
        }
        else
        {
            statusEffectController.tauntStacks = 0;
        }

        if (gameObject.GetComponent<StatusEffectController>().tauntStacks != 0)
        {
            foreach (GameObject enemy in enemyGenerator.spawnedEnemyList)
            {
                if (enemy != gameObject && enemy.GetComponent<StatusEffectController>().tauntStacks == 0)
                {
                    enemy.GetComponentInChildren<Button>().interactable = false;

                }

            }
        }
        else
        {
            int i = 0;
            foreach (GameObject enemy in enemyGenerator.spawnedEnemyList)
            {
                if (enemy.GetComponent<StatusEffectController>().tauntStacks == 0)
                {
                    i++;
                }

            }
            if (i == enemyGenerator.spawnedEnemyList.Count)
            {
                foreach (GameObject enemy in enemyGenerator.spawnedEnemyList)
                {

                    enemy.GetComponentInChildren<Button>().interactable = true;
                    i = 0;
                }
            }
        }
    }

    //Enemy turn, delay is there so it doesnt happen immediately
    IEnumerator EnemyAction(float time)
    {
 
        if (isCoroutineOn)
            yield break;

        isCoroutineOn = true;

        yield return new WaitForSeconds(time);

        action = Random.Range(1, 5);
        //action = 4;
        GameObject targetObject = gameObject;
        Component targetScript = targetObject.GetComponent(EnemyFunctionScript);
        System.Type targetType = System.Type.GetType(EnemyFunctionScript);
        System.Reflection.MethodInfo targetFunction = targetType.GetMethod(EnemyFunctionName);
        if(targetFunction != null)
        {
            targetFunction.Invoke(targetScript, null);
        }

        UpdateEnemyHealthBar(enemyCurrentHealth, enemyMaxHealth);
       // playerManager.UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);
        
        if (playerStats.playerHealth <= 0)
        {
            SceneManager.LoadScene("Lose");
        }

        isCoroutineOn = false;

    }



    public void UpdateEnemyHealthBar(float Currentvalue, float maxValue)
    {
        float percentageResult = Currentvalue / maxValue;
        enemyHealthBar.value = percentageResult;

    }

}


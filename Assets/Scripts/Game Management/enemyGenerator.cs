using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyGenerator : MonoBehaviour
{
    [SerializeField] private gameManager gameManager;


    private int amount;
    [SerializeField] private int MaxSpawn;
    [SerializeField] private int MinSpawn;
    public bool bossFight;

    //Enemy Objects
    [Header("Enemy")]
    [SerializeField] private GameObject goblin;
    [SerializeField] private GameObject knight;
    [SerializeField] private GameObject wolf;
    [SerializeField] private GameObject ent;

    //Enemy Scripts
    [SerializeField] private Goblin goblinScript;
    [SerializeField] private Knight knightScript;
    [SerializeField] private Wolf wolfScript;
    [SerializeField] private Ent entScript;


    [Header("Boss")]
    //Boss Objects
    [SerializeField] private GameObject goblinBoss;

    //Boss Scripts
    [SerializeField] private goblinBoss goblinBossScript;




    

    [HideInInspector] public GameObject spawnedEnemy;
    private GameObject enemyType;
    [SerializeField] private GameObject parent;


    public List<GameObject> spawnedEnemyList = new List<GameObject>();
    public List<GameObject> Type = new List<GameObject>();
    public List<GameObject> Boss = new List<GameObject>();

    
    private void Start()
    {
        Type[0] = goblin;
        Type[1] = knight;
        Type[2] = wolf;
        Type[3] = ent;


        Boss[0] = goblinBoss;

        

       
    }

    public void Generation()
    {

        if(!bossFight)
        {
            goblinScript.goblinStat();
            knightScript.knightStat();
            wolfScript.wolfStat();
            entScript.entStat();


            amount = Random.Range(MinSpawn, MaxSpawn);


            //Randomises how many enemies spawn
            for (int i = 0; i < amount; i++)
            {
                //Randomises which enemy from the list spawn
                enemyType = Type[Random.Range(0, Type.Count)];
                {
                    spawnedEnemy = Instantiate(enemyType, new Vector2((Screen.width / (amount + 1)) * (i + 1), -15), Quaternion.identity);
                    spawnedEnemy.transform.SetParent(parent.transform, false);
                    spawnedEnemyList.Add(spawnedEnemy);
                    StatGeneration();
                    spawnedEnemy.GetComponent<enemyManager>().enemyCount = i;

                    //spawnedEnemy.GetComponent<enemyManager>().enabled = false;

                }
            }
        }
        else
        {
            goblinBossScript.goblinBossStat();

            amount = 1;

            for(int i = 0; i < amount; i++)
            {
                enemyType = Boss[Random.Range(0, Boss.Count)];
                { 
                    spawnedEnemy = Instantiate(enemyType, new Vector2((Screen.width / (amount + 1)) * (i + 1), -15), Quaternion.identity);
                    spawnedEnemy.transform.SetParent(parent.transform, false);
                    spawnedEnemyList.Add(spawnedEnemy);
                    StatGeneration();
                    spawnedEnemy.GetComponent<enemyManager>().enemyCount = i;
                }
            }
        }
       
    }

    //Grabs stats from individual enemy csv
    public void StatGeneration()
    {

        spawnedEnemy.GetComponent<enemyManager>().enemyMaxHealth = Random.Range(spawnedEnemy.GetComponent<enemyManager>().enemyMinHealth, spawnedEnemy.GetComponent<enemyManager>().enemyMaxHealth);
        spawnedEnemy.GetComponent<enemyManager>().enemyCurrentHealth = spawnedEnemy.GetComponent<enemyManager>().enemyMaxHealth;
    }

}

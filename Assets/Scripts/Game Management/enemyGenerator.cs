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


    //Enemy Objects
    [SerializeField] private GameObject goblin;
    [SerializeField] private GameObject knight;

    //Enemy Scripts
    [SerializeField] private Goblin goblinScript;
    [SerializeField] private Knight knightScript;

    private GameObject spawnedEnemy;
    private GameObject enemyType;
    [SerializeField] private GameObject parent;


    public List<GameObject> spawnedEnemyList = new List<GameObject>();
    public List<GameObject> Type = new List<GameObject>();

    
    private void Start()
    {
        Type[0] = goblin;
        Type[1] = knight;

        

        goblin.SetActive(true);
        knight.SetActive(true);

       
    }

    public void Generation()
    {
        goblinScript.goblinStat();
        knightScript.knightStat();


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

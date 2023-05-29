using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossGenerator : MonoBehaviour
{
    [SerializeField] private gameManager gameManager;


    private int amount;
    [SerializeField] private int MaxSpawn;
    [SerializeField] private int MinSpawn;


    //Enemy Objects
    [SerializeField] private GameObject goblinBoss;

    //Enemy Scripts


    private GameObject spawnedEnemy;
    private GameObject enemyType;
    [SerializeField] private GameObject parent;


    public List<GameObject> spawnedEnemyList = new List<GameObject>();
    public List<GameObject> Type = new List<GameObject>();


    private void Start()
    {
        Type[0] = goblinBoss;

    }


    public void Generation()
    {

        amount = Random.Range(MinSpawn, MaxSpawn);


        //Randomises which enemy from the list spawn
        enemyType = Type[Random.Range(0, Type.Count)];
        {
            spawnedEnemy = Instantiate(enemyType, new Vector2((Screen.width / (amount + 1)) * (1), -15), Quaternion.identity);
            spawnedEnemy.transform.SetParent(parent.transform, false);
            spawnedEnemyList.Add(spawnedEnemy);
            StatGeneration();
            //spawnedEnemy.GetComponent<enemyManager>().enemyCount = i;

        }
    }


    public void StatGeneration()
    {

        spawnedEnemy.GetComponent<enemyManager>().enemyMaxHealth = Random.Range(spawnedEnemy.GetComponent<enemyManager>().enemyMinHealth, spawnedEnemy.GetComponent<enemyManager>().enemyMaxHealth);
        spawnedEnemy.GetComponent<enemyManager>().enemyCurrentHealth = spawnedEnemy.GetComponent<enemyManager>().enemyMaxHealth;
    }

}

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



    [SerializeField] private GameObject goblin;
    [SerializeField] private GameObject enemyTwo;

    private GameObject spawnedEnemy;
    private GameObject enemyType;
    [SerializeField] private GameObject parent;


    public List<GameObject> spawnedEnemyList = new List<GameObject>();
    public List<GameObject> Type = new List<GameObject>();

    private void Start()
    {
        Type[0] = goblin;
        Type[1] = enemyTwo;


        
    }

    public void Generation()
    {
        amount = Random.Range(MinSpawn, MaxSpawn);

        for (int i = 0; i < amount; i++)
        {
            enemyType = Type[Random.Range(0, Type.Count)];
            {
                spawnedEnemy = Instantiate(enemyType, new Vector2((Screen.width / (amount + 1)) * (i + 1), -15), Quaternion.identity);
                spawnedEnemy.transform.SetParent(parent.transform, false);
                spawnedEnemyList.Add(spawnedEnemy);
            }
        }
    }

}

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

}

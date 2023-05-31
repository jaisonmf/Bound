using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemySelection : MonoBehaviour
{
    [SerializeField] private playerManager playerManager;
    [SerializeField] private Button selectButton;
    [SerializeField] private GameObject enemy;

    public void Start()
    {
        enemy = gameObject;
     
        playerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
    }

    public void Select(int select)
    {
        if(select == 0 && playerManager.selecting == true)
        {
            Action();
        }
    }


    public void Action()
    {
 
        playerManager.PlayerAttack(enemy.GetComponent<enemyManager>().enemyCount);

        //this.transform.parent.GetComponent<enemyManager>().UpdateEnemyHealthBar(this.transform.parent.GetComponent<enemyManager>().enemyCurrentHealth, this.transform.parent.GetComponent<enemyManager>().enemyHealth);
    }
}

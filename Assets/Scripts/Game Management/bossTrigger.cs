using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossTrigger : MonoBehaviour
{

    private enemyGenerator enemyGenerator;


    private void Awake()
    {
        enemyGenerator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();

        enemyGenerator.bossFight = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public int playerMaxHealth = 100;
    public int playerHealth;
    public int playerMaxDamage = 10;
    public int playerMinDamage = 5;
    public int playerEnergy;
    public int playerMaxEnergy = 3;


    [Header("equippables")]
    public GameObject equippedHead = null;
    public GameObject equippedBody = null;
    public GameObject equippedLeftArm = null;
    public GameObject equippedRightArm = null;
    public GameObject equippedLeftLeg = null;
    public GameObject equippedRightLeg = null;

    [Header("prefab equips")]
    public GameObject PrefabequippedHead = null;
    public GameObject PrefabequippedBody = null;
    public GameObject PrefabequippedLeftArm = null;
    public GameObject PrefabequippedRightArm = null;
    public GameObject PrefabequippedLeftLeg = null;
    public GameObject PrefabequippedRightLeg = null;




    public bool returnToMap;

    public void Start()
    {
        playerHealth = playerMaxHealth;
        playerEnergy = playerMaxEnergy;
    }


}

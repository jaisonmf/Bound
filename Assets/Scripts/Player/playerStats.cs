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

    public bool returnToMap;

    public void Start()
    {
        playerHealth = playerMaxHealth;
        playerEnergy = playerMaxEnergy;
    }


}

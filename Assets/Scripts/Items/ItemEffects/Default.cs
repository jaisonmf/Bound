using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default : MonoBehaviour
{
    private textUpdate textUpdate;
    private playerStats playerStats;
    public void Start()
    {
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        textUpdate = GameObject.Find("Character").GetComponent<textUpdate>();
      
    }


    public void EquipHead()
    {
        playerStats.playerMaxHealth += 10;
        textUpdate.UpdateStats();
    }


    public void EquipBody()
    {
        playerStats.playerMaxHealth += 20;
        textUpdate.UpdateStats();
    }

    public void EquipRightArm()
    {
        playerStats.playerMaxDamage += 5;
        textUpdate.UpdateStats();
    }

    public void EquipLeftArm()
    {
        playerStats.playerMinDamage += 5;
        textUpdate.UpdateStats();
    }
    public void EquipRightLeg()
    {
        playerStats.playerMaxEnergy += 1;
        textUpdate.UpdateStats();
    }
    public void EquipLeftLeg()
    {
        playerStats.playerMaxEnergy += 1;
        textUpdate.UpdateStats();

    }


    public void UnequipHead()
    {
        playerStats.playerMaxHealth -= 10;
        textUpdate.UpdateStats();
    }


    public void UnequipBody()
    {
        playerStats.playerMaxHealth -= 20;
        textUpdate.UpdateStats();
    }

    public void UnequipRightArm()
    {
        playerStats.playerMaxDamage -= 5;
        textUpdate.UpdateStats();
    }

    public void UnequipLeftArm()
    {
        playerStats.playerMinDamage -= 5;
        textUpdate.UpdateStats();
    }
    public void UnequipRightLeg()
    {
        playerStats.playerMaxEnergy -= 1;
        textUpdate.UpdateStats();
    }
    public void UnequipLeftLeg()
    {
        playerStats.playerMaxEnergy -= 1;
        textUpdate.UpdateStats();

    }
}

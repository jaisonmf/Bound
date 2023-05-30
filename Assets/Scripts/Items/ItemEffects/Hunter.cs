using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    private textUpdate textUpdate;
    [SerializeField] private playerStats playerStats;
    public void Start()
    {
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();


    }
    public void EquipHead()
    {
        playerStats.playerMinDamage += 5;
        playerStats.playerMaxDamage += 5;
        
        textUpdate = GameObject.Find("Character").GetComponent<textUpdate>();
        textUpdate.UpdateStats();
    }


    public void EquipBody()
    {
        playerStats.playerMaxHealth -= 15;
        Debug.Log("effect");
        textUpdate = GameObject.Find("Character").GetComponent<textUpdate>();
        textUpdate.UpdateStats();
    }

    public void EquipRightArm()
    {
        playerStats.playerMaxDamage += 10;
        textUpdate = GameObject.Find("Character").GetComponent<textUpdate>();
        textUpdate.UpdateStats();
    }

    public void EquipLeftArm()
    {
        playerStats.playerMinDamage += 10;
        textUpdate = GameObject.Find("Character").GetComponent<textUpdate>();
        textUpdate.UpdateStats();
    }
    public void EquipRightLeg()
    {
        playerStats.playerMaxEnergy += 2;
        textUpdate = GameObject.Find("Character").GetComponent<textUpdate>();
        textUpdate.UpdateStats();
    }
    public void EquipLeftLeg()
    {
        playerStats.playerMaxEnergy += 2;
        textUpdate = GameObject.Find("Character").GetComponent<textUpdate>();
        textUpdate.UpdateStats();

    }


    public void UnequipHead()
    {
        playerStats.playerMinDamage -= 5;
        playerStats.playerMaxDamage -= 5;
        textUpdate = GameObject.Find("Character").GetComponent<textUpdate>();
        textUpdate.UpdateStats();
    }


    public void UnequipBody()
    {
        playerStats.playerMaxHealth += 15;
        textUpdate = GameObject.Find("Character").GetComponent<textUpdate>();
        textUpdate.UpdateStats();
    }

    public void UnequipRightArm()
    {
        playerStats.playerMaxDamage -= 10 ;
        textUpdate = GameObject.Find("Character").GetComponent<textUpdate>();
        textUpdate.UpdateStats();
    }

    public void UnequipLeftArm()
    {
        playerStats.playerMinDamage -= 10;
        textUpdate = GameObject.Find("Character").GetComponent<textUpdate>();
        textUpdate.UpdateStats();
    }
    public void UnequipRightLeg()
    {
        playerStats.playerMaxEnergy -= 2;
        textUpdate = GameObject.Find("Character").GetComponent<textUpdate>();
        textUpdate.UpdateStats();
    }
    public void UnequipLeftLeg()
    {
        playerStats.playerMaxEnergy -= 2;
        textUpdate = GameObject.Find("Character").GetComponent<textUpdate>();
        textUpdate.UpdateStats();

    }
}

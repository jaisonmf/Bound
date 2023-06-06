using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HunterAbilities : MonoBehaviour
{
    public int energyCost;


    public void HunterHeadAbility()
    {
        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();

        PlayerManager.MinDamage *= 2;
        PlayerManager.MaxDamage *= 2;
        PlayerManager.selecting = true;
        foreach (Transform child in PlayerManager.buttonSet2.transform)
        {
            if (child.name == "Back")
            {
                child.GetComponent<Button>().interactable = true;
                Debug.Log("works");
            }
            else
            {
                child.GetComponent<Button>().interactable = false;
            }
            Debug.Log(child);


        }
        playerStats.playerEnergy -= energyCost;
        PlayerManager.UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);
        playerStats.playerHealth -= 5;
        PlayerManager.UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);

    }

    public void HunterBodyAbility()
    {
        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();

        playerStats.playerHealth += 40;
        PlayerManager.UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);
        playerStats.playerEnergy -= energyCost;
        PlayerManager.UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);
    }

    public void HunterLarmAbility()
    {
        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        enemyGenerator enemyGenerator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();

        PlayerManager.selecting = true;
        foreach (Transform child in PlayerManager.buttonSet2.transform)
        {
            if (child.name == "Back")
            {
                child.GetComponent<Button>().interactable = true;
            }
            else
            {
                child.GetComponent<Button>().interactable = false;
            }


        }
        PlayerManager.ApplyFire = true;
        playerStats.playerEnergy -= energyCost;
        PlayerManager.UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);
      

    }

    public void HunterRarmAbility()
    {
        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        enemyGenerator enemyGenerator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();

        PlayerManager.selecting = true;
        foreach (Transform child in PlayerManager.buttonSet2.transform)
        {
            if (child.name == "Back")
            {
                child.GetComponent<Button>().interactable = true;
            }
            else
            {
                child.GetComponent<Button>().interactable = false;
            }


        }
        PlayerManager.HealthSteal = true;
        playerStats.playerEnergy -= energyCost;
        PlayerManager.UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);

    }
    public void HunterLlegAbility()
    {


        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();



        playerStats.playerHealth -= 10;
        PlayerManager.UpdateHealthBar(playerStats.playerHealth, playerStats.playerMaxHealth);
        playerStats.playerEnergy++;
        PlayerManager.UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);

    }

    public void HunterRlegbility()
    {
        playerManager PlayerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();

        PlayerManager.MinDamage = PlayerManager.MaxDamage;

        foreach (Transform child in PlayerManager.buttonSet2.transform)
        {
            if (child.name == "Back")
            {
                child.GetComponent<Button>().interactable = true;
            }
            else
            {
                child.GetComponent<Button>().interactable = false;
            }


        }
        PlayerManager.energyOverflow = true;
        playerStats.playerEnergy -= energyCost;
        PlayerManager.UpdateEnergyBar(playerStats.playerEnergy, playerStats.playerMaxEnergy);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textUpdate : MonoBehaviour
{
    private playerStats playerStats;
    private Text Healthtext;
    private Text DamageText;
    private Text EnergyText;


    public void Start()
    {
        Healthtext = GameObject.Find("Healthtext").GetComponent<Text>();
        DamageText = GameObject.Find("Damagetext").GetComponent<Text>();
        EnergyText = GameObject.Find("Energytext").GetComponent<Text>();
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();

        UpdateStats();
    }

    public void UpdateStats()
    {
        Healthtext.text = (playerStats.playerMaxHealth.ToString());
        DamageText.text = (playerStats.playerMinDamage.ToString() + " / " + playerStats.playerMaxDamage.ToString());
        EnergyText.text = (playerStats.playerMaxEnergy.ToString());
    }
}

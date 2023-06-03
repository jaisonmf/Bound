using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hoverController : MonoBehaviour
{

    private playerStats playerStats;
    private enemyManager enemyManager;
    private enemyGenerator enemyGenerator;
    private GameObject currentEnemy;


    //Hover Text
    public GameObject hoverBox;
    RectTransform rt;
    public Text hoverText;
    public Text titleText;

    private bool isHovering = false;






    private void Start()
    {
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        enemyGenerator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();


        rt = hoverBox.GetComponent<RectTransform>();
        hoverBox.SetActive(false);
        hoverText.text = "";
        titleText.text = "";
    }





    public void PlayerHealthText()
    {
        if (!isHovering)
        {
            isHovering = true;
            hoverBox.SetActive(true);
            titleText.text = "HP:" + playerStats.playerHealth.ToString() + "/" + playerStats.playerMaxHealth.ToString();
            StartCoroutine(ResetHoverCooldown());
        }
    }
    
   
    public void EnergyText()
    {
        if (!isHovering)
        {
            isHovering = true;
            hoverBox.SetActive(true);
            titleText.text = "Energy:" + playerStats.playerEnergy.ToString() + "/" + playerStats.playerMaxEnergy.ToString();
            StartCoroutine(ResetHoverCooldown());
        }
    }

   





    private IEnumerator ResetHoverCooldown()
    {
        yield return new WaitForSeconds(1f);
        isHovering = false;
        hoverBox.SetActive(false);
        hoverText.text = "";
        titleText.text = "";
        currentEnemy = null;
    }




    public void HoverExit()
    {
        if (!isHovering)
        {
            hoverBox.SetActive(false);
            rt.sizeDelta = new Vector2(800, 150);
            hoverText.text = "";
            titleText.text = "";
        }
    }

}

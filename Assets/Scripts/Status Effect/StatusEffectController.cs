using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectController : MonoBehaviour
{
    [SerializeField] private HorizontalLayoutGroup layoutGroup;
    private playerStats playerStats;
    private playerManager playerManager;


    [SerializeField] private GameObject onFireIcon;
    private bool onFire;
    [SerializeField] private int onFireStacks;



    public void Start()
    {
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        playerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
    }

    public void AddEffect()
    {
        if(onFire == false)
        {
            onFire = true;
            playerManager.statusEffect.Add(onFireIcon);
            onFireStacks++;

            foreach (GameObject obj in playerManager.statusEffect)
            {
                Instantiate(obj, layoutGroup.transform);
            }
        }
        else if (onFire == true)
        {
            onFireStacks++;
        }

      
    }

    public void EffectUpdate()
    {
        int damage;

        if (onFire == true)
        {
            damage = 10 + onFireStacks;
            playerStats.playerHealth -= damage;

        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectController : MonoBehaviour
{
    [SerializeField] private HorizontalLayoutGroup layoutGroup;
    private playerStats playerStats;
    private playerManager playerManager;
    private enemyManager enemyManager;
    public List<GameObject> statusEffect;

    [SerializeField] Text stacksText;


    [SerializeField] private GameObject onFireIcon;
    private bool onFire;
    [SerializeField] private int onFireStacks;

    [SerializeField] private GameObject TauntIcon;
    private bool taunting;
    public int tauntStacks;


    public void Start()
    {
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        playerManager = GameObject.Find("playerManager").GetComponent<playerManager>();
        enemyManager = gameObject.GetComponent<enemyManager>();

    }

    public void AddOnFire()
    {
        if(onFire == false)
        {
            onFire = true;
            statusEffect.Add(onFireIcon);
            onFireStacks++;

            foreach (GameObject obj in statusEffect)
            {
                Instantiate(obj, layoutGroup.transform);
            }
            onFireIcon.GetComponentInChildren<Text>().text = onFireStacks.ToString();
        }
        else if (onFire == true)
        {
            onFireStacks++;
            onFireIcon.GetComponentInChildren<Text>().text = onFireStacks.ToString();
        }
        
        

      
    }
    public void AddTaunt()
    {
        if(taunting == false)
        {
            taunting = true;
            statusEffect.Add(TauntIcon);
            tauntStacks++;

            foreach (GameObject obj in statusEffect)
            {
                Instantiate(obj, layoutGroup.transform);
            }
            TauntIcon.GetComponentInChildren<Text>().text = tauntStacks.ToString();
        }

        else if (taunting == true)
        {
            tauntStacks++;
            TauntIcon.GetComponentInChildren<Text>().text = tauntStacks.ToString();
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

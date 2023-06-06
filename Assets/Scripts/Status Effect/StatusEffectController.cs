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
    [HideInInspector] public bool onFire;
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
        GameObject debuff = null;
        if(onFire == false)
        {
            onFire = true;

            statusEffect.Add(onFireIcon);
          
            foreach (GameObject obj in statusEffect)
            {
                debuff = Instantiate(obj, layoutGroup.transform);
            }
            
            onFireStacks++;
            onFireIcon = debuff;
            debuff.GetComponentInChildren<Text>().text = onFireStacks.ToString();
           
        }
        else if (onFire == true)
        {

            onFireStacks++;
            onFireIcon.GetComponentInChildren<Text>().text = onFireStacks.ToString();

        }
      
    




    }
    public void AddTaunt()
    {
        GameObject debuff = null;
        if(taunting == false)
        {
            taunting = true;
            statusEffect.Add(TauntIcon);
          
            foreach (GameObject obj in statusEffect)
            {
                debuff = Instantiate(obj, layoutGroup.transform);
            }
            tauntStacks++;
            TauntIcon = debuff;
            TauntIcon.GetComponentInChildren<Text>().text = tauntStacks.ToString();

        }

        else if (taunting == true)
        {
            tauntStacks++;
            TauntIcon.GetComponentInChildren<Text>().text = tauntStacks.ToString();
        }
        

    }

  


}

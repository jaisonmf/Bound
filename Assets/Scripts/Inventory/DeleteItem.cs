using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteItem : MonoBehaviour
{
    [SerializeField] private Button LeaveMap;
    [SerializeField] private Button ThrowAway;
    public bool deleting = false;
    private playerStats playerStats;


    public void Start()
    {
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();

    }



    public void Delete(int Button)
    {
        if (Button == 1 && deleting == false)
        {
            deleting = true;
            LeaveMap.interactable = false;

        }
        else if(Button == 1 && deleting == true)
        {
            deleting = false;
            LeaveMap.interactable = true;

        }
    }




}

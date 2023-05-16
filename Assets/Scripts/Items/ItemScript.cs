using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemScript : MonoBehaviour
{
    private playerInventory playerInventory;
    public bool Equipped;
    public GameObject myprefab;

    public void Start()
    {
        playerInventory = GameObject.Find("playerStats").GetComponent<playerInventory>();
 
    }

    public void GrabItem()
    {
        if (playerInventory.inventory.Count != 9)
        {
            playerInventory.inventory.Add(myprefab);
        }
        else
        {
            exit();
        }
    }


    public void exit()
    {
        SceneManager.LoadScene("MapScene");
    }

}


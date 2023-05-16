using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemScript : MonoBehaviour
{
    private playerInventory playerInventory;
    private GameObject item;

    public void Start()
    {
        playerInventory = GameObject.Find("playerStats").GetComponent<playerInventory>();
        item = this.gameObject;
    }

    public void GrabItem()
    {
        if (playerInventory.inventory.Count != 9)
        {
            playerInventory.Instance.inventory.Add(item);
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


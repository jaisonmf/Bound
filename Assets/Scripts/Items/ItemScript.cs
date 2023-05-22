using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ItemScript : MonoBehaviour
{
    private playerInventory playerInventory;
    
    public bool Equipped;
    public GameObject myprefab;
    public bool inInventory = false;
    public Inventory inventory;
    private MapEvent mapEvent;
    public GameObject inventorySpot;


    public void Start()
    {
        playerInventory = GameObject.Find("playerStats").GetComponent<playerInventory>();
        mapEvent = GameObject.Find("Map").GetComponent<MapEvent>();

    }

    public void GrabItem()
    {
        if (playerInventory.inventory.Count != 9 && inventory == null)
        {
            playerInventory.inventory.Add(myprefab);
            exit();
        }
        else if (playerInventory.inventory.Count == 9 && inventory == null)
        {
            exit();
        }
    }


    public void exit()
    {
        inInventory = false; 
        SceneManager.LoadScene("MapScene");
        mapEvent.GetComponent<Canvas>().enabled = true;
    }
    
    public void FindInventory()
    {
        inventory = GameObject.Find("InventoryContainer").GetComponent<Inventory>();
        
         if(inventory != null)
         {
             this.gameObject.GetComponent<imageSnap>().isEnabled = true;
         }
         else
         {
            this.gameObject.GetComponent<imageSnap>().isEnabled = false;
         }
       

    }
  






}


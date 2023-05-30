using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitInventory : MonoBehaviour
{
    private Inventory inventory;
    private MapEvent mapEvent;
    private playerInventory playerInventory;



    public void Start()
    {
        mapEvent = GameObject.Find("Map").GetComponent<MapEvent>();
        inventory = GameObject.Find("InventoryContainer").GetComponent<Inventory>();
        playerInventory = GameObject.Find("playerStats").GetComponent<playerInventory>();

    }

    public void ToMap()
    {
        playerInventory.inventory.Clear();
        inventory.inInventory = false;
        SceneManager.LoadScene("MapScene");
        mapEvent.GetComponent<Canvas>().enabled = true;


    }

}

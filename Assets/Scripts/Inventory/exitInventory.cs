using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitInventory : MonoBehaviour
{
    private Inventory inventory;
    private MapEvent mapEvent;



    public void Start()
    {
        mapEvent = GameObject.Find("Map").GetComponent<MapEvent>();
        inventory = GameObject.Find("InventoryContainer").GetComponent<Inventory>();

    }

    public void ToMap()
    {
        inventory.inInventory = false;
        SceneManager.LoadScene("MapScene");
        mapEvent.GetComponent<Canvas>().enabled = true;


    }

}

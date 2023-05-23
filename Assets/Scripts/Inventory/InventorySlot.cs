using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public bool full;
    public GameObject storedItem;

    private void Update()
    {
        if(gameObject.transform.childCount != 1)
        {
            full = true;
        }
        else
        {
            full = false;
        }

    }
    /*
    public void Start()
    {
        Instantiate(storedItem);
        storedItem.transform.SetParent(gameObject.transform, false);
        storedItem.GetComponent<ItemScript>().EquippedItem();
    }
    */
}

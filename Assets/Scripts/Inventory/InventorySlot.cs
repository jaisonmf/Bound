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
        Vector3 position = gameObject.transform.position;
        GameObject item = Instantiate(storedItem, position, Quaternion.identity, transform);
        
        item.transform.SetParent(gameObject.transform, false);
        item.transform.localScale = Vector3.one * 0.5f;
        item.GetComponent<ItemScript>().FindInventory();
        item.GetComponent<ItemScript>().inInventory = true;
        //Debug.Log(item);
        
        if (item != null)
        {
            item.GetComponent<ItemScript>().EquippedItem();
        }
        
        
    }
    */
}

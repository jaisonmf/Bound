using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public bool full;
    public GameObject storedItem;
    private playerStats playerStats;
    private string currentTag;

    public void UpdateSlot()
    {
        if(gameObject.transform.childCount != 1)
        {
            full = true;
        }
        else
        {
            full = false;
        }

        currentTag = gameObject.tag;
        GameObject prefab;
        if(currentTag == "Head")
        {
            prefab = storedItem.GetComponent<ItemScript>().myprefab;
            playerStats.equippedHead = prefab;
        }
        else if (currentTag == "Body")
        {
            prefab = storedItem.GetComponent<ItemScript>().myprefab;
            playerStats.equippedBody = prefab;
        }

        else if (currentTag == "LeftArm")
        {
            prefab = storedItem.GetComponent<ItemScript>().myprefab;
            playerStats.equippedLeftArm = prefab;
        }

        else if (currentTag == "RightArm")
        {
            prefab = storedItem.GetComponent<ItemScript>().myprefab;
            playerStats.equippedRightArm = prefab;
        }

        else if (currentTag == "LeftLeg")
        {
            prefab = storedItem.GetComponent<ItemScript>().myprefab;
            playerStats.equippedLeftLeg = prefab;
        }

        else if (currentTag == "RightLeg")
        {
            prefab = storedItem.GetComponent<ItemScript>().myprefab;
            playerStats.equippedRightLeg = prefab;
        }
    }
    
    public void Start()
    {
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        
       
        GameObject spawnedItem = null;
        string currentTag = gameObject.tag;
        if (playerStats.equippedHead != null && currentTag == "Head" )
        {
            spawnedItem = playerStats.equippedHead;
        }
        else if (playerStats.equippedBody != null && currentTag == "Body")
        {
            spawnedItem = playerStats.equippedBody;
        }
        else if (playerStats.equippedLeftArm != null && currentTag == "LeftArm")
        {
            spawnedItem = playerStats.equippedLeftArm;
        }
        else if (playerStats.equippedRightArm != null && currentTag == "RightArm")
        {
            spawnedItem = playerStats.equippedRightArm;
        }
        else if (playerStats.equippedLeftLeg != null && currentTag == "LeftLeg")
        {
            spawnedItem = playerStats.equippedLeftLeg;
        }
        else if (playerStats.equippedRightLeg != null && currentTag == "RightLeg")
        {
            spawnedItem = playerStats.equippedRightLeg;
        }
  

        if(spawnedItem != null)
        {
            Vector3 position = gameObject.transform.position;
            GameObject item = Instantiate(spawnedItem, position, Quaternion.identity, transform);

            item.transform.SetParent(gameObject.transform, false);
            item.transform.localScale = Vector3.one * 0.5f;
            item.GetComponent<ItemScript>().FindInventory();
            item.GetComponent<ItemScript>().inInventory = true;

            if (item != null)
            {
                item.GetComponent<ItemScript>().EquippedItem();
            }
        }
       
    }

}

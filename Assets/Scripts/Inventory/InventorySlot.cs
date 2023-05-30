using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
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
            playerStats.PrefabequippedHead = prefab;
            playerStats.equippedHead = storedItem;

        }
        else if (currentTag == "Body")
        {
            prefab = storedItem.GetComponent<ItemScript>().myprefab;
            playerStats.PrefabequippedBody = prefab;
            playerStats.equippedBody = storedItem;
        }

        else if (currentTag == "LeftArm")
        {
            prefab = storedItem.GetComponent<ItemScript>().myprefab;
            playerStats.PrefabequippedLeftArm = prefab;
            playerStats.equippedLeftArm = storedItem;
        }

        else if (currentTag == "RightArm")
        {
            prefab = storedItem.GetComponent<ItemScript>().myprefab;
            playerStats.PrefabequippedRightArm = prefab;
            playerStats.equippedRightArm = storedItem;
        }

        else if (currentTag == "LeftLeg")
        {
            prefab = storedItem.GetComponent<ItemScript>().myprefab;
            playerStats.PrefabequippedLeftLeg = prefab;
            playerStats.equippedLeftLeg = storedItem;
        }

        else if (currentTag == "RightLeg")
        {
            prefab = storedItem.GetComponent<ItemScript>().myprefab;
            playerStats.PrefabequippedRightLeg = prefab;
            playerStats.equippedRightLeg = storedItem;
        }
    }
    
    public void Start()
    {
        storedItem = null;
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();


     
    
        
       
      
       

        GameObject spawnedItem = null;
        string currentTag = gameObject.tag;
        if (playerStats.PrefabequippedHead != null && currentTag == "Head" )
        {
            playerStats.equippedHead = Instantiate(playerStats.PrefabequippedHead);
            spawnedItem = playerStats.equippedHead;
        }
        else if (playerStats.PrefabequippedBody != null && currentTag == "Body")
        {
            playerStats.equippedBody = Instantiate(playerStats.PrefabequippedBody);
            spawnedItem = playerStats.equippedBody;
        }
        else if (playerStats.PrefabequippedLeftArm != null && currentTag == "LeftArm")
        {
            playerStats.equippedLeftArm = Instantiate(playerStats.PrefabequippedLeftArm);
            spawnedItem = playerStats.equippedLeftArm;
        }
        else if (playerStats.PrefabequippedRightArm != null && currentTag == "RightArm")
        {
            playerStats.equippedRightArm = Instantiate(playerStats.PrefabequippedRightArm);
            spawnedItem = playerStats.equippedRightArm;
        }
        else if (playerStats.PrefabequippedLeftLeg != null && currentTag == "LeftLeg")
        {
            playerStats.equippedLeftLeg = Instantiate(playerStats.PrefabequippedLeftLeg);
            spawnedItem = playerStats.equippedLeftLeg;
        }
        else if (playerStats.PrefabequippedRightLeg != null && currentTag == "RightLeg")
        {
            playerStats.equippedRightLeg = Instantiate(playerStats.PrefabequippedRightLeg);
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
            item.GetComponent<imageSnap>().isEnabled = true;


        }
       
    }

}

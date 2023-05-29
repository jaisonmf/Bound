using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public bool full;
    public GameObject storedItem;
    private playerStats playerStats;
    private string currentTag;

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

        currentTag = gameObject.tag;
        if(currentTag == "Head")
        {
            playerStats.equippedHead = storedItem.GetComponent<ItemScript>().myprefab;
        }
        else if (currentTag == "Body")
        {
            playerStats.equippedBody = storedItem.GetComponent<ItemScript>().myprefab;
        }

        else if (currentTag == "LeftArm")
        {
            playerStats.equippedLeftArm = storedItem.GetComponent<ItemScript>().myprefab;
        }

        else if (currentTag == "RightArm")
        {
            playerStats.equippedRightArm = storedItem.GetComponent<ItemScript>().myprefab;
        }

        else if (currentTag == "LeftLeg")
        {
            playerStats.equippedLeftLeg = storedItem.GetComponent<ItemScript>().myprefab;
        }

        else if (currentTag == "RightLeg")
        {
            playerStats.equippedRightLeg = storedItem.GetComponent<ItemScript>().myprefab;
        }
    }
    
    public void Start()
    {
        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        currentTag = gameObject.tag;
       
        if (full == true)
        {
            Debug.Log("BAH");
            currentTag = gameObject.tag;
            GameObject spawnedItem = null;

            if (currentTag == "Head")
            {
                spawnedItem = playerStats.equippedHead;
            }
            else if (currentTag == "Body")
            {
                spawnedItem = playerStats.equippedBody;
            }

            else if (currentTag == "LeftArm")
            {
                spawnedItem = playerStats.equippedLeftArm;
            }

            else if (currentTag == "RightArm")
            {
                spawnedItem = playerStats.equippedRightArm;
            }

            else if (currentTag == "LeftLeg")
            {
                spawnedItem = playerStats.equippedLeftLeg;
            }

            else if (currentTag == "RightLeg")
            {
                spawnedItem = playerStats.equippedRightLeg;
            }



            Vector3 position = gameObject.transform.position;
            GameObject item = Instantiate(spawnedItem, position, Quaternion.identity, transform);

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


    }
    
}

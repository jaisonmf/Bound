using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    private playerInventory playerInventory;
    public int inventoryCount;
    [HideInInspector] public GameObject parent;
    private GameObject spawnedItem;
    [SerializeField] private float scaleMultiplier;
    private GameObject item;
    public bool inInventory;
    public int inventoryCounter;
    public List<GameObject> numberofInventory;
    public GameObject objectToDelete;

    //Inventory Grid
    private int columns = 3;
    private Vector2 gridSize = new Vector2(941f, 1163f);

    public void Start()
    {
        
        playerInventory = GameObject.Find("playerStats").GetComponent<playerInventory>();


        //Grabbing the inventory to add to prefab inventory
        foreach (GameObject prefab in playerInventory.Prefabinventory)
        {
            GameObject copiedPrefab = prefab;
            playerInventory.inventory.Add(copiedPrefab);
        }



        GenerateInventory();

        //THIS NEEDS TO GO AFTER GENERATEINVENTORY
        ItemScript[] objectsWithScript = FindObjectsOfType<ItemScript>();
        foreach (ItemScript obj in objectsWithScript)
        {

            obj.FindInventory();
        }
        inInventory = true;

        

        

        /*
        GameObject[] instance = FindObjectsOfType<GameObject>();
        int instancesCount = instance.Length;
        int deletionCount = 0;
        for (int i = 0; i < instancesCount; i++)
        {
            if (instance[i] == objectToDelete)
            {
                deletionCount++;
            }
            if(deletionCount == 2)
            {
                Destroy(instance[i]);
                break;
            }
        }
        */

    }

  


    public void GenerateInventory()
    {
        
       

        //Inventory Generator
        inventoryCount = playerInventory.inventory.Count;
        int rows = Mathf.CeilToInt((float)inventoryCount / (float)columns);

        float elementSizeX = gridSize.x / columns;
        float elementSizeY = gridSize.y / rows;  // Divide by rows instead of columns

        int nameNumber = 0;
        for (int i = 0; i < inventoryCount; i++)
        {
            int row = i / columns;
            int column = i % columns;

            Vector3 localPosition = new Vector3((column * elementSizeX) + (elementSizeX / 2f), -(row * elementSizeY) - (elementSizeY / 2f), 0f);  // Adjust the Y position calculation

            Vector3 position = transform.TransformPoint(localPosition);

            
            GameObject Inventoryslot = Instantiate(new GameObject(), position, Quaternion.identity, transform);
            nameNumber++;
            Inventoryslot.name = "InventorySlot" + nameNumber;
            Inventoryslot.transform.SetParent(parent.transform, false);
            Inventoryslot.AddComponent<removeChild>();

            GameObject itemPrefab = playerInventory.inventory[i];
            GameObject item = Instantiate(itemPrefab, position, Quaternion.identity, transform);
            playerInventory.inventory[i] = item;
            item.transform.SetParent(parent.transform, false);
            item.transform.localScale = Vector3.one * scaleMultiplier;
            
            item.GetComponent<ItemScript>().inventorySpot = Inventoryslot;
         

        }
    }

}

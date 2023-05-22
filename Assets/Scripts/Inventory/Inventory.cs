using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    private playerInventory playerInventory;
    public int inventoryCount;
    [SerializeField] private GameObject parent;
    private GameObject spawnedItem;
    [SerializeField] private float scaleMultiplier;
    private GameObject item;
    public bool inInventory;
    

    //Inventory Grid
    private int columns = 3;
    private Vector2 gridSize = new Vector2(941f, 1163f);

    public void Start()
    {
        playerInventory = GameObject.Find("playerStats").GetComponent<playerInventory>();
        
       

        GenerateInventory();


        ItemScript[] objectsWithScript = FindObjectsOfType<ItemScript>();

        foreach (ItemScript obj in objectsWithScript)
        {
            obj.FindInventory();
        }
        inInventory = true;
    }




    public void GenerateInventory()
    {
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

            GameObject itemPrefab = playerInventory.inventory[i];
            GameObject item = Instantiate(itemPrefab, position, Quaternion.identity, transform);
            playerInventory.inventory[i] = item;
            item.transform.SetParent(parent.transform, false);
            item.transform.localScale = Vector3.one * scaleMultiplier;
            item.GetComponent<ItemScript>().inventorySpot = Inventoryslot;

        }
    }

}

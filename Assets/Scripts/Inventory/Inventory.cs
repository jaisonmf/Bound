using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    private playerInventory playerInventory;
    public int inventoryCount;
    [SerializeField] private GameObject parent;
    private GameObject spawnedItem;
    private float scaleMultiplier = 0.5f;
    private ItemScript itemScript;

    //Inventory Grid
    private int columns = 3;
    private Vector2 gridSize = new Vector2(941f, 1163f);

    private void Start()
    {
        playerInventory = GameObject.Find("playerStats").GetComponent<playerInventory>();
        ItemScript[] objectsWithScript = FindObjectsOfType<ItemScript>();

        foreach (ItemScript obj in objectsWithScript)
        {
            obj.inInventory = true;
        }
        

        GenerateInventory();
    }




    public void GenerateInventory()
    {
       inventoryCount = playerInventory.inventory.Count;
        int rows = Mathf.CeilToInt((float)inventoryCount / (float)columns);


        float elementSizeX = gridSize.x / columns;
        float elementSizeY = gridSize.y / columns;  



        for(int i = 0; i < inventoryCount; i++)
        {
            int row = i / columns;
            int column = i % columns;

            Vector3 localPosition = new Vector3((column * elementSizeX) + (elementSizeX / 2f), (row * elementSizeY) + (elementSizeY / 2f), 0f);


            Vector3 position = transform.TransformPoint(localPosition);

            spawnedItem = Instantiate(playerInventory.inventory[i], position, Quaternion.identity, transform);
            spawnedItem.transform.SetParent(parent.transform, false);
            spawnedItem.transform.localScale = Vector3.one * scaleMultiplier;
        }
    }

}

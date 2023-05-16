using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Chest1 : MonoBehaviour
{
    public List<GameObject> ChestList;
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject parent;
    private int amount = 3;
    [SerializeField] private GameObject spawneditem;

    public void Start()
    {
        parent = GameObject.Find("ItemSpawn");
        
    }

    public void Chest1Items()
    {
        

        // item1 = Instantiate(spawneditem, item1.transform);
        for(int i = 0; i < amount; i++)
        {
            spawneditem = ChestList[Random.Range(0, ChestList.Count)];
            {
                item = Instantiate(spawneditem, new Vector2((Screen.width / (amount + 1)) * (i + 1), -15), Quaternion.identity);
                item.GetComponent<ItemScript>().myprefab = spawneditem;
                item.transform.SetParent(parent.transform, false);
            }
            
        }
        
   
    }
}

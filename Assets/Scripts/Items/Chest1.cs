using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Chest1 : MonoBehaviour
{
    public List<GameObject> ChestList;
    [SerializeField] private GameObject item1;
    [SerializeField] private GameObject item2;
    [SerializeField] private GameObject item3;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject spawneditem;

    public void Start()
    {
        item1 = GameObject.Find("ChestSpawn1");
        item2 = GameObject.Find("ChestSpawn2");
        item3 = GameObject.Find("ChestSpawn3");
        parent = GameObject.Find("Canvas");
    }

    public void Chest1Items()
    {
        

        // item1 = Instantiate(spawneditem, item1.transform);
        for(int i = 0; i < 3; i++)
        {
            spawneditem = ChestList[Random.Range(0, ChestList.Count)];
            item1 = Instantiate(spawneditem, new Vector2((Screen.width / 3 * 1), -15), Quaternion.identity);
        }
        item1 = Instantiate(spawneditem, new Vector2((Screen.width / 3 * 1), -15), Quaternion.identity);
        item1.transform.SetParent(parent.transform, false);
        /*
        spawneditem = ChestList[Random.Range(0, ChestList.Count)];
        Instantiate(item2, item2.transform);
        spawneditem.transform.SetParent(parent.transform, false);

        spawneditem = ChestList[Random.Range(0, ChestList.Count)];
        Instantiate(item3, item3.transform);
        spawneditem.transform.SetParent(parent.transform, false);
        */
    }
}

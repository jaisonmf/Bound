using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventory : MonoBehaviour
{
    [SerializeField] private GameObject Inventory;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject SpawnedInventory;

    public void OpenInventory(int Button)
    {
        if(Button == 1)
        {
            SpawnedInventory = Instantiate(Inventory);
            SpawnedInventory.transform.SetParent(parent.transform, false);
        }
    }

    public void CloseInventory(int Button)
    {
        if (Button == 1)
        {
            SpawnedInventory = GameObject.Find("OpenInventory").GetComponent<ShowInventory>().SpawnedInventory;
            Destroy(SpawnedInventory);
        }
    }
}

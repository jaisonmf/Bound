using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToInventory : MonoBehaviour
{
    public void ToInventory()
    {
        SceneManager.LoadScene("Inventory");
        GameObject Inventory = GameObject.Find("Character").GetComponentInChildren<Inventory>().gameObject;
        Inventory.SetActive(true);
        Inventory.GetComponent<Inventory>().GenerateInventory();

    }
}

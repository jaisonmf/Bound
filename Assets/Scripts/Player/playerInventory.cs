using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerInventory : MonoBehaviour
{
    

    public static playerInventory instance;
    public static playerInventory Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<playerInventory>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject("playerInventory");
                    instance = singleton.AddComponent<playerInventory>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return instance;
        }
    }


    public Transform persistantParent;
    public List<GameObject> inventory;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach(GameObject item in inventory)
        {
            if(item != null)
            {
                item.transform.SetParent(transform);
            }
        }
    }

    public void Additem(GameObject item)
    {
        inventory.Add(item);
        item.transform.SetParent(persistantParent);
    }

    public void RemoveItem(GameObject item)
    {
        inventory.Remove(item);
        item.transform.SetParent(null);
    }
}

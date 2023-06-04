using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitOverview : MonoBehaviour
{

    public Transform parentObject;
    public void Exit(int button)
    {
        if(button == 1)
        {
            ItemOverview itemOverview = GameObject.Find("ItemOverview").GetComponent<ItemOverview>();
            Inventory inventory = GameObject.Find("InventoryContainer").GetComponent<Inventory>();




            EnableImages(parentObject);
            inventory.itemOverview.SetActive(false);
   

        }
    }

    public void EnableImages(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Image imageComponent = child.GetComponent<Image>();
            Text textComponent = child.GetComponent<Text>();

            if (imageComponent != null)
            {
                imageComponent.enabled = true;
            }

            if (textComponent != null)
            {
                textComponent.enabled = true;
            }

            // Recursively call DisableImagesRecursive for children of the current child
            EnableImages(child);
        }
    }
}

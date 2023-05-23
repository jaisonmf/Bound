using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class imageSnap : MonoBehaviour
{
    [SerializeField] private bool isSnapped;
    private Inventory inventory;
    private Image image;
    private Transform targetTransform;
    [HideInInspector] public Vector2 previousTransform;
    public bool isEnabled;
    private playerInventory Playerinventory;
    private ItemScript itemScript;
    [HideInInspector] public bool inInventory = true;
    [HideInInspector]public GameObject parent;
    private removeChild removeChild;
    private textUpdate textUpdate;

    void Start()
    {
        image = GetComponent<Image>();
        textUpdate = GameObject.FindObjectOfType<textUpdate>();
        previousTransform = transform.position;
        Playerinventory = GameObject.Find("playerStats").GetComponent<playerInventory>();
        itemScript = GetComponent<ItemScript>();
        inventory = GameObject.Find("InventoryContainer").GetComponent<Inventory>();
    }
    
    public void SnapToTarget()
    {
        if (isEnabled && inInventory == true)
        {
            GameObject snapPointObject = null;

            string currentTag = gameObject.tag;
            GameObject parent = itemScript.inventorySpot;
            bool full = parent.transform.childCount > 0;

            if (currentTag == "Head")
            {
                snapPointObject = GameObject.Find("Head");
            }
            else if (currentTag == "Body")
            {
                snapPointObject = GameObject.Find("Body");
            }
            else if (currentTag == "RightArm")
            {
                snapPointObject = GameObject.Find("RightArm");
            }
            else if (currentTag == "LeftArm")
            {
                snapPointObject = GameObject.Find("LeftArm");
            }
            else if (currentTag == "RightLeg")
            {
                snapPointObject = GameObject.Find("RightLeg");
            }
            else if (currentTag == "LeftLeg")
            {
                snapPointObject = GameObject.Find("LeftLeg");
            }

            if (snapPointObject != null && full == false)
            {
                Transform snapPointTransform = snapPointObject.transform;

                if (!isSnapped && snapPointTransform != null)
                {
                    targetTransform = snapPointTransform;
                    image.transform.SetParent(targetTransform, false);
                    image.rectTransform.anchoredPosition = Vector2.zero;
                    isSnapped = true;
                    inInventory = false;
                    Playerinventory.inventory.Remove(this.gameObject);
                    textUpdate.UpdateStats();

                }
            }
            else
            {
                ReturntoInventory();
            }
        }
        else
        {
            ReturntoInventory();
        }



    }

    public void ReturntoInventory()
    {
        if (inInventory == false)
        {
            Transform snapPointTransform = itemScript.inventorySpot.transform;
            parent = GameObject.Find("InventoryContainer");

            if (snapPointTransform != null)
            {

                targetTransform = snapPointTransform;
                image.transform.SetParent(snapPointTransform.transform, false);
                image.rectTransform.anchoredPosition = Vector2.zero;
                isSnapped = false;
                inInventory = true;

                removeChild[] objectswithScript = GameObject.FindObjectsOfType<removeChild>();
                foreach (removeChild action in objectswithScript)
                {
                    action.RemoveChild();
                }


                Playerinventory.inventory.Add(this.gameObject);
                textUpdate.UpdateStats();
              



            }
        }
    }



}
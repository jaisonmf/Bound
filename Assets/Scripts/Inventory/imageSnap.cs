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
    private bool full;

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


            InventorySlot inventorySlot = snapPointObject.GetComponent<InventorySlot>();

            if (snapPointObject != null && inventorySlot.full == false)
            {
                Transform snapPointTransform = snapPointObject.transform;

                if (!isSnapped && snapPointTransform != null)
                {
                    targetTransform = snapPointTransform;
                    image.transform.SetParent(targetTransform, false);
                    image.rectTransform.anchoredPosition = Vector2.zero;
                    isSnapped = true;
                    inInventory = false;
                    Playerinventory.inventory.Remove(gameObject);
                    textUpdate.UpdateStats();
                    GameObject Equippeditem = gameObject.GetComponent<ItemScript>().myprefab;
                    snapPointObject.GetComponent<InventorySlot>().storedItem = Equippeditem;
                    gameObject.GetComponent<ItemScript>().EquippedItem();

                }
            }
            else if (inventorySlot.full == true)
            {
                // Store the original parent of the current item
                Transform originalParent = gameObject.transform.parent;

                // Swap the positions of the current item and the occupied item
                Vector3 originalPosition = gameObject.transform.position;
                Vector3 occupiedPosition = inventorySlot.storedItem.transform.position;

                gameObject.transform.SetParent(inventorySlot.storedItem.transform.parent, true);
                inventorySlot.storedItem.transform.SetParent(originalParent, true);

                gameObject.transform.position = occupiedPosition;
                inventorySlot.storedItem.transform.position = originalPosition;

                // Swap the stored items in the inventory slots
                inventorySlot.storedItem = gameObject;
                gameObject.GetComponent<ItemScript>().EquippedItem();
            }
            else if(gameObject.GetComponent<ItemScript>().equipped == true)
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
                gameObject.GetComponent<ItemScript>().UnEquipItem();
                textUpdate.UpdateStats();
              



            }
        }
    }



}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class imageSnap : MonoBehaviour
{
    [SerializeField] private bool isSnapped;
    private Transform transform;
    private Image image;
    private Transform targetTransform;
    [SerializeField] private Vector2 previousTransform;
    public bool isEnabled;
    private playerInventory Playerinventory;
    private ItemScript itemScript;
    public bool inInventory = true;


    void Start()
    {
        image = GetComponent<Image>();
        transform = GetComponent<Transform>();
        previousTransform = transform.position;
        Playerinventory = GameObject.Find("playerStats").GetComponent<playerInventory>();
        itemScript = GetComponent<ItemScript>();
        Debug.Log(inInventory);
    }
    
    public void SnapToTarget()
    {
        if (isEnabled && inInventory == true)
        {
            GameObject snapPointObject = null;
            Transform inventorySnap = transform;
            string currentTag = gameObject.tag;
            

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

            if (snapPointObject != null)
            {
                Transform snapPointTransform = snapPointObject.transform;

                if (!isSnapped && snapPointTransform != null)
                {
                    targetTransform = snapPointTransform;
                    image.transform.SetParent(targetTransform, false);
                    image.rectTransform.anchoredPosition = Vector2.zero;
                    isSnapped = true;
                    inInventory = false;
  
                }
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

            if(snapPointTransform != null)
            {
                targetTransform = snapPointTransform;
                image.transform.SetParent(targetTransform, false);
                image.rectTransform.anchoredPosition = Vector2.zero;
                isSnapped = false;
                inInventory = true;
            }
        }
    }
    
    
}
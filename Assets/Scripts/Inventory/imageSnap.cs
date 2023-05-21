using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class imageSnap : MonoBehaviour
{
    [SerializeField] private bool isSnapped = false;
    private Transform transform;
    private Image image;
    private Transform targetTransform;
    private Transform previousTransform;
    public bool isEnabled;


    void Start()
    {
        image = GetComponent<Image>();
        transform = GetComponent<Transform>();
    }

    public void SnapToTarget()
    {
        if (!isEnabled)
            return;

        GameObject snapPointObject = null;
        string currentTag = gameObject.tag;
        previousTransform = transform;

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
            snapPointObject = GameObject.Find("Body");
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
            }
        }
    }

    public void ReturntoInventory()
    {
        GameObject inventorySlot = null;
        if (isSnapped)
        {
            Transform inventorySnapPoint = inventorySlot.transform;
            
        }
    }


}
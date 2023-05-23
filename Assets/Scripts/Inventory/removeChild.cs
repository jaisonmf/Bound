using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeChild : MonoBehaviour
{


    public void RemoveChild()
    {

        if (gameObject.transform.childCount != 0)
        {
            imageSnap childComponent = gameObject.GetComponentInChildren<imageSnap>();
            if (childComponent != null)
            {
                GameObject child = childComponent.gameObject;
                GameObject container = GameObject.Find("InventoryContainer");

                child.transform.SetParent(container.transform, false);
                Vector2 previousTransform = child.GetComponent<imageSnap>().previousTransform;

                child.transform.position = new Vector3(previousTransform.x, previousTransform.y, child.transform.position.z);
            }
        }
    }
}

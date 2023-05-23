using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public bool full;

    private void Update()
    {
        if(gameObject.transform.childCount != 1)
        {
            full = true;
        }
        else
        {
            full = false;
        }

    }

}

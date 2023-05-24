using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ItemScript : MonoBehaviour
{
    private playerInventory playerInventory;
    
    public GameObject myprefab;
    public bool inInventory = false;
    public Inventory inventory;
    private MapEvent mapEvent;
    public GameObject inventorySpot;
    public bool equipped;


    [Header("Equip")]
    public string targetScriptName;
    public string targetObjectName;
    public string EquipFunctionName;

    [Header("Unequip")]
    public string UnequipFunctionName;


    public void Start()
    {
        playerInventory = GameObject.Find("playerStats").GetComponent<playerInventory>();
        mapEvent = GameObject.Find("Map").GetComponent<MapEvent>();

    }

    public void GrabItem()
    {
        if (playerInventory.inventory.Count != 9 && inventory == null)
        {
            playerInventory.Prefabinventory.Add(myprefab);
            exit();
        }
        else if (playerInventory.inventory.Count == 9 && inventory == null)
        {
            exit();
        }
    }


    public void exit()
    {
        inInventory = false; 
        SceneManager.LoadScene("MapScene");
        mapEvent.GetComponent<Canvas>().enabled = true;
    }
    
    public void FindInventory()
    {
        inventory = GameObject.Find("InventoryContainer").GetComponent<Inventory>();
        
         if(inventory != null)
         {
             gameObject.GetComponent<imageSnap>().isEnabled = true;
         }
         else
         {
            gameObject.GetComponent<imageSnap>().isEnabled = false;
         }
       

    }
  

    public void RemoveFromList(GameObject objToRemove)
    {
        playerInventory.inventory.Remove(objToRemove);
    }

    public void EquippedItem()
    {
        equipped = true;
        int childIndex = 0;
        if(childIndex >= 0 && childIndex < gameObject.transform.childCount)
        {
            GameObject childObject = gameObject.transform.GetChild(childIndex).gameObject;
            
            if(childObject != null)
            {
                targetObjectName = childObject.name;
                GameObject targetObject = GameObject.Find(targetObjectName);
                
                
                if(targetObject != null)
                {
                    Component targetScript = targetObject.GetComponent(targetScriptName);
                    
                    if (targetScript != null)
                    {
                        System.Type targetType = System.Type.GetType(targetScriptName);
                        System.Reflection.MethodInfo targetFunction = targetType.GetMethod(EquipFunctionName);
     
                        if (targetFunction != null)
                        {

                            targetFunction.Invoke(targetScript, null);
                            
                            
                        }
                    }
                }
            }
        }

    }
    
    public void UnEquipItem()
    {
        equipped = false;
        int childIndex = 0;
        if (childIndex >= 0 && childIndex < gameObject.transform.childCount)
        {
            GameObject childObject = gameObject.transform.GetChild(childIndex).gameObject;

            if (childObject != null)
            {
                targetObjectName = childObject.name;
                GameObject targetObject = GameObject.Find(targetObjectName);


                if (targetObject != null)
                {
                    Component targetScript = targetObject.GetComponent(targetScriptName);

                    if (targetScript != null)
                    {
                        System.Type targetType = System.Type.GetType(targetScriptName);
                        System.Reflection.MethodInfo targetFunction = targetType.GetMethod(UnequipFunctionName);
        
                        if (targetFunction != null)
                        {

                            targetFunction.Invoke(targetScript, null);


                        }
                    }
                }
            }
        }
    }


}


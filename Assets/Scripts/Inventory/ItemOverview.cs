using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOverview : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    public GameObject selectedItem;
    [SerializeField] private Text ItemName;
    [SerializeField] private Text StatBoost;
    [SerializeField] private Text AbilityDescription;
    [SerializeField] private Image ItemIcon;



    public void GenerateViewer()
    {
        ItemIcon.sprite = selectedItem.GetComponent<Image>().sprite;
        ItemName.text = selectedItem.GetComponent<ItemScript>().ItemName;
        StatBoost.text = selectedItem.GetComponent<ItemScript>().Statboost;
        AbilityDescription.text = selectedItem.GetComponent<ItemScript>().Description;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalNode : MonoBehaviour
{
    public int countdown;

    public void Avaliable()
    {
        gameObject.GetComponent<Button>().interactable = true;



    }

    public void BossFight()
    {
        if(gameObject.GetComponent<Button>().interactable == true)
        {
            Debug.Log("99");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backToMap : MonoBehaviour
{

    private playerStats  inventory;
    private MapEvent mapEvent;
    private GameObject endButton;
    public void Start()
    {
        mapEvent = GameObject.Find("Map").GetComponent<MapEvent>();
        inventory = GameObject.Find("playerStats").GetComponent<playerStats>();
        endButton = GameObject.Find("End");
    }

    public void ToMap()
    {
        SceneManager.LoadScene("MapScene");
        mapEvent.GetComponent<Canvas>().enabled = true;
        

        


        for(int i = 0; i < mapEvent.rows; i++)
        {
            if(i == mapEvent.rows)
            {
                endButton.GetComponent<FinalNode>().Avaliable();
               
            }
        }
        Debug.Log(mapEvent.rows);

    }
}

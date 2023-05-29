using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMap : MonoBehaviour
{

    private playerStats  inventory;
    private MapEvent mapEvent;
    public void Start()
    {
        //mapEvent = GameObject.Find("Map").GetComponent<MapEvent>();
        inventory = GameObject.Find("playerStats").GetComponent<playerStats>();
    }

    public void ToMap()
    {
        SceneManager.LoadScene("MapScene");
        mapEvent.GetComponent<Canvas>().enabled = true;

    }
}

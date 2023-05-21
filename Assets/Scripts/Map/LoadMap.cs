using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMap : MonoBehaviour
{

    private MapEvent mapEvent;


    public void Start()
    {
        mapEvent = GameObject.Find("Map").GetComponent<MapEvent>();
       // mapEvent.GetComponent<Canvas>().enabled = true; 
    }



}

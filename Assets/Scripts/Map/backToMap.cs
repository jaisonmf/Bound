using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMap : MonoBehaviour
{


    private MapEvent mapEvent;
    public void Start()
    {
        //mapEvent = GameObject.Find("Map").GetComponent<MapEvent>();

    }

    public void ToMap()
    {
        SceneManager.LoadScene("MapScene");
        mapEvent.GetComponent<Canvas>().enabled = true;
    }
}

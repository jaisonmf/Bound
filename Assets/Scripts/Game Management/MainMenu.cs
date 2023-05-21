using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private MapEvent mapEvent;


    public void Start()
    {
        mapEvent = GameObject.Find("Map").GetComponent<MapEvent>();


    }


    public void Menu(int Button)
    {
        if (Button == 0)
        {
            if(mapEvent.mainMenu == false)
            {
                mapEvent.GetComponent<Canvas>().enabled = true;
            }
            SceneManager.LoadScene("MapScene");

            mapEvent.mainMenu = false;
            mapEvent.MapGeneration();
        }
        else if (Button == 1)
        {
            Application.Quit();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    private MapEvent mapEvent;


    public void Start()
    {
        mapEvent = GameObject.Find("Map").GetComponent<MapEvent>();
    }

    //Win
    public void Win(int Button)
    {
        if(Button == 0)
        {
            int random;
            random = Random.Range(1, 10);
            if(random == 1)
            {
                SceneManager.LoadScene("ItemScene");
            }
            else
            {
                SceneManager.LoadScene("MapScene");
            }
            

        }
        else if (Button == 1)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }



    //Lose
    public void Lose(int Button)
    {
        if (Button == 0)
        {
            SceneManager.LoadScene("MainMenu");

        }
        else if (Button == 1)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}

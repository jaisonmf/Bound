using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    

    //Win
    public void Win(int Button)
    {
        if(Button == 0)
        {
            SceneManager.LoadScene("MapScene");

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

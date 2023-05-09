using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{



    public void Menu(int Button)
    {
        if (Button == 0)
        {
            SceneManager.LoadScene("MapScene");

        }
        else if (Button == 1)
        {
            Application.Quit();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{


    public void NextZone(int button)
    {
        if(button == 0)
        {
            Debug.Log("next zone");
        }
        else if (button == 1)
        {
            Debug.Log("next zone");
        }
        else if (button == 2)
        {
            Debug.Log("next zone");
        }
        else
        {
            Application.Quit();
        }
    }
}

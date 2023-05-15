using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemScript : MonoBehaviour
{

    public void exit()
    {
        SceneManager.LoadScene("MapScene");
    }

}


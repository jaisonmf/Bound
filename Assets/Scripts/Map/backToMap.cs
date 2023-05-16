using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMap : MonoBehaviour
{

    public void ToMap()
    {
        SceneManager.LoadScene("MapScene");
    }
}

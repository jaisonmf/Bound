using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToInventory : MonoBehaviour
{
    public void ToInventory()
    {
        SceneManager.LoadScene("Inventory");
    }
}

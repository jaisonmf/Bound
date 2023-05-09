using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapNode : MonoBehaviour
{
    public List<GameObject> futurenodes = new List<GameObject>();
    public List<GameObject> previousnodes = new List<GameObject>();
    public bool maxFutureConnections;
    public bool maxPreviousConnections;


    public void ButtonInteract(int Number)
    {
        if(Number == 1)
        {
            SceneManager.LoadScene("CombatScene");
        }

        if(Number == 2)
        {
            SceneManager.LoadScene("RestScene");
        }
    }
}

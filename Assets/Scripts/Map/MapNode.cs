using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapNode : MonoBehaviour
{
    public List<GameObject> futurenodes = new List<GameObject>();
    public List<GameObject> previousnodes = new List<GameObject>();
    public bool maxFutureConnections;
    public bool maxPreviousConnections;
    public GameObject arrow;
    private FinalNode finalNode;
   

    public void Start()
    {


        if(previousnodes.Count == 0)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }

        finalNode = GameObject.Find("End").GetComponent<FinalNode>();
    }



    public void ButtonInteract(int Number)
    {
        MapEvent mapEvent = GameObject.Find("Map").GetComponent<MapEvent>();
        if (Number == 1)
        {
            SceneManager.LoadScene("CombatScene");
        }

        if(Number == 2)
        {
            SceneManager.LoadScene("RestScene");
        }
        if(Number == 3)
        {
            SceneManager.LoadScene("UpgradeScene");
        }
        if(Number == 4)
        {
            SceneManager.LoadScene("ItemScene");
        }

        
        foreach (GameObject button in mapEvent.buttons)
        {
            button.GetComponent<Button>().interactable = false;
        }
        foreach (GameObject gameObject in futurenodes)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        gameObject.GetComponent<Button>().interactable = false;
        finalNode.countdown++;

       
        if(finalNode.countdown == mapEvent.rows)
        {
            finalNode.Avaliable();
        }

    }

}

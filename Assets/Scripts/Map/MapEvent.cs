using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEngine.UI;

public class MapEvent : MonoBehaviour
{
    public List<GameObject> events = new List<GameObject>();


    [SerializeField] private GameObject enemyEncounter;
    [SerializeField] private GameObject rest;
    [SerializeField] private GameObject upgrade;
    [SerializeField] private GameObject parent;
    [SerializeField] private int rows;
    [SerializeField] private GameObject Arrow;
    [SerializeField] private GameObject spawnedArrow;

    [SerializeField] private GameObject point1;
    [SerializeField] private GameObject point2;
    public GameObject map;
    private playerStats playerStats;
    public bool mainMenu;

    [SerializeField] public List<List<GameObject>> location = new List<List<GameObject>>();




    private void Start()
    {
        events[0] = enemyEncounter;
        events[1] = enemyEncounter;
        events[2] = rest;
        events[3] = upgrade;

        playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();

        
    }
    public void MapGeneration()
    {
        //Generate map at start of game
        if (playerStats.returnToMap == false && mainMenu == false)
        {

            ButtonSpawn();
            
            
        }
        //Player returns to map from another scene
        else if (playerStats.returnToMap == true && mainMenu == false)
        {
            map.SetActive(true);
        }

    }


    public void ButtonSpawn()
    {
        //Generates how many buttons are in a row
        for (int i = 0; i < rows; i++)
        {
            List<GameObject> innerList = new List<GameObject>();
            location.Add(innerList);
            int tempListLength = Random.Range(2, 5);
            for (int j = 0; j < tempListLength; j++)
            {
                //Generates what button spawns
                
                var tempSpawn = Instantiate(events[Random.Range(0, events.Count)]);
                location[i].Add(tempSpawn);
                tempSpawn.transform.SetParent(parent.transform, false);
                tempSpawn.transform.position = new Vector3((point2.transform.position.x - point1.transform.position.x)/ (rows + 1) * (i + 1) - (0 - point1.transform.position.x), Screen.height / (tempListLength + 1) * (j + 1), 0);

            }

            if (i != 0)
            {
                //Current Row is smaller than future row
                int currentRow;
                int otherRow;
                bool iteratingTheCurrent;
                if (location[i].Count < location[i - 1].Count)
                {

                    currentRow = i - 1;
                    otherRow = i;
                    iteratingTheCurrent = false;
                }
                else
                {
                //Current row is larger than future row

                    otherRow = i - 1;
                    currentRow = i;
                    iteratingTheCurrent = true;
                }

                int otherListIndex = 0;
                int currentListIndex = 0;


                for (int l = 0; l < location[currentRow].Count; l++)
                {
                    if (location[otherRow].Count - otherListIndex == location[currentRow].Count - currentListIndex)
                    {
                        //Current row is equal to future row
 
                        if (iteratingTheCurrent)
                        {
                            location[i][currentListIndex].GetComponent<MapNode>().previousnodes.Add(location[i - 1][otherListIndex]);
                            location[i - 1][otherListIndex].GetComponent<MapNode>().futurenodes.Add(location[i][currentListIndex]);
                            currentListIndex++;
                            otherListIndex++;
                        }
                        else
                        
                        {
                            location[i - 1][currentListIndex].GetComponent<MapNode>().futurenodes.Add(location[i][otherListIndex]);
                            location[i][otherListIndex].GetComponent<MapNode>().previousnodes.Add(location[i - 1][currentListIndex]);
                            currentListIndex++;
                            otherListIndex++;
                        }

                    }
                    
                    else if (location[otherRow].Count - otherListIndex * 2 < location[currentRow].Count - currentListIndex && iteratingTheCurrent == false && otherListIndex != 0 && location[i - 1][otherListIndex - 1].GetComponent<MapNode>().maxPreviousConnections == false)
                    {
                        location[i - 1][currentListIndex].GetComponent<MapNode>().futurenodes.Add(location[i][otherListIndex - 1]);
                        location[i][otherListIndex - 1].GetComponent<MapNode>().previousnodes.Add(location[i - 1][currentListIndex]);
                        currentListIndex++;
                        if (location[i - 1][otherListIndex - 1].GetComponent<MapNode>().previousnodes.Count == 2)
                        {
                            
                            location[i - 1][otherListIndex - 1].GetComponent<MapNode>().maxPreviousConnections = true;
                        }
                    }

                    else if (location[otherRow].Count - otherListIndex * 2 < location[currentRow].Count - currentListIndex && iteratingTheCurrent && otherListIndex != 0 && location[i - 1][otherListIndex - 1].GetComponent<MapNode>().maxFutureConnections == false)
                    {
                        location[i][currentListIndex].GetComponent<MapNode>().previousnodes.Add(location[i - 1][otherListIndex - 1]);
                        location[i - 1][otherListIndex - 1].GetComponent<MapNode>().futurenodes.Add(location[i][currentListIndex]);
                        currentListIndex++;
                        if (location[i - 1][otherListIndex - 1].GetComponent<MapNode>().futurenodes.Count == 2)
                        {
                            
                            location[i - 1][otherListIndex - 1].GetComponent<MapNode>().maxFutureConnections = true;
                        }
                    }
                    else
                    {
                        //Current row has a choice to what they connect to
                        
                        int tempRand = Random.Range(0, location[i].Count - currentListIndex);

                        if (tempRand == 0 && otherListIndex != 0 && iteratingTheCurrent && location[i - 1][otherListIndex - 1].GetComponent<MapNode>().maxFutureConnections == false)
                        {
                            location[i][currentListIndex].GetComponent<MapNode>().previousnodes.Add(location[i - 1][otherListIndex - 1]);
                            location[i - 1][otherListIndex - 1].GetComponent<MapNode>().futurenodes.Add(location[i][currentListIndex]);
                            currentListIndex++;
                            if (location[i - 1][otherListIndex - 1].GetComponent<MapNode>().futurenodes.Count == 2)
                            {
                                
                                location[i - 1][otherListIndex - 1].GetComponent<MapNode>().maxFutureConnections = true;
                            }
                        }
                        else if (tempRand == 0 && otherListIndex != 0 && iteratingTheCurrent == false && location[i - 1][otherListIndex - 1].GetComponent<MapNode>().maxPreviousConnections == false)
                        {
                            location[i - 1][currentListIndex].GetComponent<MapNode>().futurenodes.Add(location[i][otherListIndex - 1]);
                            location[i][otherListIndex - 1].GetComponent<MapNode>().previousnodes.Add(location[i - 1][currentListIndex]);
                            currentListIndex++;
                            if (location[i - 1][otherListIndex - 1].GetComponent<MapNode>().previousnodes.Count == 2)
                            {
                                
                                location[i - 1][otherListIndex - 1].GetComponent<MapNode>().maxPreviousConnections = true;
                            }
                        }
                    
                        else
                        {
                            if (iteratingTheCurrent)
                            {
                                location[i][currentListIndex].GetComponent<MapNode>().previousnodes.Add(location[i - 1][otherListIndex]);
                                location[i - 1][otherListIndex].GetComponent<MapNode>().futurenodes.Add(location[i][currentListIndex]);
                                currentListIndex++;
                                otherListIndex++;
                            }
                            else
                            {
                                location[i - 1][currentListIndex].GetComponent<MapNode>().futurenodes.Add(location[i][otherListIndex]);
                                location[i][otherListIndex].GetComponent<MapNode>().previousnodes.Add(location[i - 1][currentListIndex]);
                                currentListIndex++;
                                otherListIndex++;
                            }
                        }

                    
                    }


                }

                
            }

        }
        playerStats.returnToMap = true;

        /*
        //Arrow spawn
        for (int i = 0; i < location.Count; i++)
        {
            for(int l = 0; l < location[i].Count; l++)
            {
                for (int j = 0; j < location[i][l].GetComponent<MapNode>().futurenodes.Count; j++)
                {
                   Vector3 spawnposition = location[i][l].GetComponent<MapNode>().futurenodes[j].transform.position;
                   
                    GameObject instantiatedObject = Instantiate(Arrow, spawnposition, Quaternion.identity);
                    instantiatedObject.transform.position = (location[i][l].transform.position);
                    instantiatedObject.transform.SetParent(parent.transform, false);
                    
                }
            }
        }
        */
    }
}

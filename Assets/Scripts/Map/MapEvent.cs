using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapEvent : MonoBehaviour
{
    public List<GameObject> events = new List<GameObject>();


    [SerializeField] private GameObject enemyEncounter;
    [SerializeField] private GameObject rest;
    [SerializeField] private GameObject parent;
    [SerializeField] private int rows;
    [SerializeField] private int connections = 2;


    [SerializeField] public List<List<GameObject>> location = new List<List<GameObject>>();




    private void Start()
    {
        events[0] = enemyEncounter;
        events[1] = enemyEncounter;
        events[2] = enemyEncounter;
        events[3] = rest;


        ButtonSpawn();
    }


    public void ButtonSpawn()
    {
        for (int i = 0; i < rows; i++)
        {
            List<GameObject> innerList = new List<GameObject>();
            location.Add(innerList);
            for (int j = 0; j < Random.Range(2, 4); j++)
            {
                
                var tempSpawn = Instantiate(events[Random.Range(0, events.Count)]);
                location[i].Add(tempSpawn);
                tempSpawn.transform.SetParent(parent.transform, false);
                tempSpawn.transform.position = new Vector3(j * 100, i * 100, 0);
            }
            Debug.Log(i);
            if (i != 0)
            {
                int currentRow;
                int otherRow;
                bool iteratingTheCurrent;
                if (location[i].Count < location[i - 1].Count)
                {
                    Debug.Log("current is smaller");
                    currentRow = i - 1;
                    otherRow = i;
                    iteratingTheCurrent = false;
                }
                else
                {
                    Debug.Log("current is larger");
                    otherRow = i - 1;
                    currentRow = i;
                    iteratingTheCurrent = true;
                }

                int otherListIndex = 0;
                int currentListIndex = 0;


                for (int l = 0; l < location[currentRow].Count; l++)
                {
                    if (location[otherRow].Count * 2 < location[currentRow].Count)
                    {
                        Debug.Log("larger");
                        if (iteratingTheCurrent)
                        {

                            location[i][currentListIndex].GetComponent<MapNode>().previousnodes.Add(location[i - 1][otherListIndex - 1]);
                            location[i - 1][otherListIndex - 1].GetComponent<MapNode>().futurenodes.Add(location[i][currentListIndex]);
                            currentListIndex++;
                        }
                        else
                        {
                            location[i - 1][currentListIndex].GetComponent<MapNode>().futurenodes.Add(location[i][otherListIndex - 1]);
                            location[i][otherListIndex - 1].GetComponent<MapNode>().previousnodes.Add(location[i - 1][currentListIndex]);
                            currentListIndex++;
                        }
                    }

                    else if (location[otherRow].Count - otherListIndex == location[currentRow].Count - currentListIndex)
                    {
                        Debug.Log("equal");
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
                    else
                    {
                        Debug.Log("choice");


                        if (Random.Range(0, location[i].Count - currentListIndex) == 0 && otherListIndex != 0)
                        {
                            if (iteratingTheCurrent)
                            {
                                location[i][currentListIndex].GetComponent<MapNode>().previousnodes.Add(location[i - 1][otherListIndex - 1]);
                                location[i - 1][otherListIndex - 1].GetComponent<MapNode>().futurenodes.Add(location[i][currentListIndex]);
                                currentListIndex++;
                            }
                            else
                            {
                                location[i - 1][currentListIndex].GetComponent<MapNode>().futurenodes.Add(location[i][otherListIndex - 1]);
                                location[i][otherListIndex - 1].GetComponent<MapNode>().previousnodes.Add(location[i - 1][currentListIndex]);
                                currentListIndex++;
                            }
                            Debug.Log(currentListIndex);
                            Debug.Log(otherListIndex);
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
            Debug.Log("skipped");

        

        }
    }
}

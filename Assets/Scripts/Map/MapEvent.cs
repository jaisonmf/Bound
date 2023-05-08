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
            for (int j = 0; j < Random.Range(2, 5); j++)
            {
                
                var tempSpawn = Instantiate(events[Random.Range(0, events.Count)]);
                location[i].Add(tempSpawn);
                tempSpawn.transform.SetParent(parent.transform, false);
                tempSpawn.transform.position = new Vector3(i * 100, j * -100, 0);
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
                    if (location[otherRow].Count - otherListIndex * 2 <= location[currentRow].Count - currentListIndex && iteratingTheCurrent && otherListIndex != 0)
                    {
                        location[i][currentListIndex].GetComponent<MapNode>().previousnodes.Add(location[i - 1][otherListIndex - 1]);
                        location[i - 1][otherListIndex - 1].GetComponent<MapNode>().futurenodes.Add(location[i][currentListIndex]);
                        currentListIndex++;
                        if (location[i - 1][otherListIndex].GetComponent<MapNode>().futurenodes.Count == 2)
                        {
                            otherListIndex++;
                        }
                    }
                    else if (location[otherRow].Count - otherListIndex * 2 < location[currentRow].Count - currentListIndex && iteratingTheCurrent == false && otherListIndex != 0)
                    {
                        location[i - 1][currentListIndex].GetComponent<MapNode>().futurenodes.Add(location[i][otherListIndex - 1]);
                        location[i][otherListIndex - 1].GetComponent<MapNode>().previousnodes.Add(location[i - 1][currentListIndex]);
                        currentListIndex++;
                        if (location[i - 1][otherListIndex].GetComponent<MapNode>().previousnodes.Count == 2)
                        {
                            otherListIndex++;
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


                        if (Random.Range(0, location[i].Count - currentListIndex) == 0 && otherListIndex != 0 && iteratingTheCurrent)
                        {
                            location[i][currentListIndex].GetComponent<MapNode>().previousnodes.Add(location[i - 1][otherListIndex - 1]);
                            location[i - 1][otherListIndex - 1].GetComponent<MapNode>().futurenodes.Add(location[i][currentListIndex]);
                            currentListIndex++;
                            if (location[i - 1][otherListIndex].GetComponent<MapNode>().futurenodes.Count == 2)
                            {
                                otherListIndex++;
                            }
                        }
                        else if (Random.Range(0, location[i].Count - currentListIndex) == 0 && otherListIndex != 0 && iteratingTheCurrent)
                        {
                            location[i - 1][currentListIndex].GetComponent<MapNode>().futurenodes.Add(location[i][otherListIndex - 1]);
                            location[i][otherListIndex - 1].GetComponent<MapNode>().previousnodes.Add(location[i - 1][currentListIndex]);
                            currentListIndex++;
                            if (location[i - 1][otherListIndex].GetComponent<MapNode>().previousnodes.Count == 2)
                            {
                                otherListIndex++;
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

        for (int i = 0; i < location.Count; i++)
        {
            for(int l = 0; l < location[i].Count; l++)
            {
                for (int j = 0; j < location[i][l].GetComponent<MapNode>().futurenodes.Count; j++)
                {
                    LineRenderer


                    lineRenderer = GetComponent<LineRenderer>();
                    lineRenderer.SetPosition(0, location[i][l].transform.position); 
                    lineRenderer.SetPosition(1, location[i][l].GetComponent<MapNode>().futurenodes[j].transform.position);
                }
            }
        }
    }
}

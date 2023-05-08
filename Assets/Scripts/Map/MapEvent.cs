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


    [SerializeField] private GameObject[] spawns;

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
        for(int i = 0; i < spawns.Length; i++)
        {
            var tempSpawn = Instantiate(events[Random.Range(0, events.Count)]);
            tempSpawn.transform.SetParent(parent.transform, false);
            tempSpawn.transform.position = new Vector3(spawns[i].transform.position.x, spawns[i].transform.position.y, spawns[i].transform.position.z);

        }
    }
}

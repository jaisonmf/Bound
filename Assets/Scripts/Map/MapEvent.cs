using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapEvent : MonoBehaviour
{
    public List<Button> events = new List<Button>();

    [SerializeField] private Button enemyEncounter;
    [SerializeField] private Button rest;
    [SerializeField] private Button spawnedButton;

    private int buttonAmount;

    [SerializeField] private GameObject spawn1;
    [SerializeField] private GameObject spawn2;
    [SerializeField] private GameObject spawn3;
    [SerializeField] private GameObject spawn4;
    [SerializeField] private GameObject spawn5;
    [SerializeField] private GameObject spawn6;
    [SerializeField] private GameObject spawn7;
    [SerializeField] private GameObject spawn8;
    [SerializeField] private GameObject spawn9;

    private void Start()
    {
        events[0] = enemyEncounter;
        events[1] = enemyEncounter;
        events[2] = enemyEncounter;
        events[3] = rest;
    }


    public void ButtonSpawn()
    {
        spawnedButton = events[Random.Range(0, events.Count)];

        buttonAmount = 9;
        for (int i = 0; i < buttonAmount; i++)
        {
            spawnedButton = events[Random.Range(0, events.Count)];
        }
    }
}

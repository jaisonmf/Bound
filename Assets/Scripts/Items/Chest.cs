using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject chest1;
    [SerializeField] private GameObject chest2;
    [SerializeField] private GameObject chest3;
    [SerializeField] private GameObject chestSpawn;
    [SerializeField] private int random;

    public void ChestGenerate()
    {
        //random = Random.Range(0, 11);
        random = 1;
        if(random <= 5)
        {
            chestSpawn = Instantiate(chest1, chestSpawn.transform);
        }
        else if (random > 5 && random < 10)
        {
            chestSpawn = Instantiate(chest2, chestSpawn.transform);
        }
        else
        {
            chestSpawn = Instantiate(chest3, chestSpawn.transform);
        }

    }
}

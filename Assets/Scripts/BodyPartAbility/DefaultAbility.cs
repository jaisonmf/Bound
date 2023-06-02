using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAbility : MonoBehaviour
{



    public void DefaultHeadAbility()
    {

    }

    public void DefaultBodyAbility()
    {
        playerStats playerStats = GameObject.Find("playerStats").GetComponent<playerStats>();
        playerStats.playerEnergy++;
    }

    public void DefaultLarmAbility()
    {

    }

    public void DefaultRarmAbility()
    {

    }
    public void DefaultLlegAbility()
    {

    }

    public void DefaultRlegbility()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    [SerializeField] enemyGenerator enemyGenerator;



    private void Start()
    {
        enemyGenerator = GameObject.Find("enemyGenerator").GetComponent<enemyGenerator>();
    }


    //Win
    public void Win(int Button)
    {
        if(Button == 0)
        {
            for(int i = 0; i < enemyGenerator.spawnedEnemyList.Count; i++)
            {
                Destroy(enemyGenerator.spawnedEnemyList[i]);
            }


            enemyGenerator.spawnedEnemyList.Clear();
            SceneManager.LoadScene("MapScene");

        }
    }



    //Lose
    public void Lose(int Button)
    {

    }

}

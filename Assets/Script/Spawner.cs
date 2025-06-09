using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    GameObject[] spawnerlist;
    private float spawnCoolDown;
    [SerializeField] float spawnRate = 2;

    public GameObject enemyPrefab;







    void Start()
    {
        spawnerlist = GameObject.FindGameObjectsWithTag("Spawner");




    }

    // Update is called once per frame
    void Update()
    {

        CheckEnemy();
    }
    public void CheckEnemy()
    {

        spawnCoolDown -= Time.deltaTime;

        if (spawnCoolDown <= 0f)
        {

            spawnCoolDown = spawnRate;
            SpawnRandomPosition();






        }
    }


    public void SpawnRandomPosition()
    {
        var a = Instantiate(enemyPrefab);
        a.transform.position = spawnerlist[Random.Range(0, spawnerlist.Length)].transform.position;
        //a.GetComponent<Enemy>().speed += v;
        //a.GetComponent<Enemy>().res = 1 + tier;
        //a.GetComponent<SpriteRenderer>().sprite = enemySprites[tier];



        //if (a.GetComponent<Enemy>().res == 2)
        //{
        //    a.GetComponent<SpriteRenderer>().sprite = enemySprites[0];
        //}
        //else if (a.GetComponent<Enemy>().res == 3)
        //{
        //    a.GetComponent<SpriteRenderer>().sprite = enemySprites[1];
        //}
        //else if (a.GetComponent<Enemy>().res == 4)
        //{
        //    a.GetComponent<SpriteRenderer>().sprite = enemySprites[2];
        //}



    }
}

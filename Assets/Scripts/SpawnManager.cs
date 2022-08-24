using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] arraySpawn;
    public float spawnTimeStart;
    public float spawnTime;
    public GameObject enemie;

    void Start()
    {
        InvokeRepeating("SpawnEnemie", spawnTimeStart, spawnTime);
    }

    void SpawnEnemie()
    {
        int randomSpawn = Random.Range(0, 2);
        Instantiate(enemie, arraySpawn[randomSpawn].position, Quaternion.identity);
    }
}

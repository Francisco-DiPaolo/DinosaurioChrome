using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] arraySpawn;
    public float spawnTimeStart;
    public float spawnTime;
    public float speedEnemy;
    public GameObject enemies;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", spawnTimeStart, spawnTime);
    }

    public void SpawnEnemies()
    {
        int randomSpawn = Random.Range(0, 2);
        Instantiate(enemies, arraySpawn[randomSpawn].position, Quaternion.identity);
    }
}
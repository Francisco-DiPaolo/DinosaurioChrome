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
        enemies = Resources.Load<GameObject>("Prefabs/Enemy");
        InvokeRepeating("SpawnEnemies", spawnTimeStart, spawnTime);
    }

  
    public void SpawnEnemies()
    {
        int randomSpawn = Random.Range(0, arraySpawn.Length);
        Instantiate(enemies, arraySpawn[randomSpawn].position, Quaternion.identity);
    }
}
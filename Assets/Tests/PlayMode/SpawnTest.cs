using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;
using NUnit.Framework;

public class SpawnTest
{
    [UnityTest]
    public IEnumerator SpawnEnemiesTest()
    {
        GameObject spawn = new GameObject { };
        spawn.AddComponent<SpawnManager>();
        SpawnManager spawnManager = spawn.GetComponent<SpawnManager>();
        Transform[] transforms = new Transform[1];
        transforms[0] = spawn.transform;
        spawnManager.arraySpawn = transforms;
        spawnManager.spawnTimeStart = 1f;
        spawnManager.spawnTime = 3f;
        spawnManager.enemies = new GameObject { };
        spawnManager.enemies.tag = "Enemy";

        int random = Random.Range(1, 6);
        for (int i = 0; i < random; i++) spawnManager.SpawnEnemies();

        yield return new WaitForSeconds(10f);

        Assert.AreEqual(random, GameObject.FindGameObjectsWithTag("Enemy").Length);
    }
}
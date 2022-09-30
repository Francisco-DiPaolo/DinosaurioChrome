using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpawnAndDestroyTest
{
    [UnityTest]
    public IEnumerator SpawnAndDestroyTestWithEnumeratorPasses()
    {
        GameObject spawner = new GameObject { };
        spawner.AddComponent<SpawnManager>();
        SpawnManager spawnManager = spawner.GetComponent<SpawnManager>();
        Transform[] transforms = new Transform[1];
        transforms[0] = spawner.transform;

        spawnManager.arraySpawn = transforms;
        spawnManager.spawnTimeStart = 1;
        spawnManager.spawnTime = 3;
        spawnManager.speedEnemy = 4;
        spawnManager.name = "Spawn Manager";

        GameObject colliderDestroy = new GameObject { };
        colliderDestroy.AddComponent<BoxCollider2D>();
        BoxCollider2D collider = colliderDestroy.GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.size.Set(2, 4);
        collider.transform.position = new Vector3(-30, 0, 0);
        collider.name = "Zone Dead";
        collider.tag = "TriggerDeadZone";

        Assert.IsTrue(Vector2.Distance(spawnManager.transform.position, collider.transform.position) > 3);

        yield return new WaitForSeconds(7);

        spawnManager.CancelInvoke();

        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        Assert.AreEqual(3, enemy.Length);

        yield return new WaitForSeconds(7.5f);

        Assert.AreEqual(0, GameObject.FindGameObjectsWithTag("Enemy").Length);
    }
}

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class JumpTest
{
    [UnityTest]
    public IEnumerator JumpTestWithEnumeratorPasses()
    {
        GameObject player = new GameObject();
        player.AddComponent<Player>();
        player.AddComponent<Rigidbody2D>();
        player.AddComponent<BoxCollider2D>();
        player.transform.position = new Vector3(0, 1, 0);
        Player pl = player.GetComponent<Player>();
        pl.speed = 10;
        pl.jump = 0;
        pl.jumpForce = 3;
        pl.maxJump = 1;

        GameObject grounded = new GameObject { };
        grounded.AddComponent<BoxCollider2D>();
        BoxCollider2D gr = grounded.GetComponent<BoxCollider2D>();
        gr.size = new Vector2(6, 1);
        gr.transform.position = new Vector3(0, 0, 0);
        gr.tag = "Floor";

        yield return new WaitForSeconds(2f);

        Vector3 originalPos = player.transform.position;
        pl.Jump();

        yield return new WaitForSeconds(0.2f);

        float vel = player.GetComponent<Rigidbody2D>().velocity.y;

        Assert.IsTrue(player.transform.position.y > originalPos.y);

        yield return new WaitForSeconds(0.1f);

        pl.Jump();
        Assert.IsTrue(vel > player.GetComponent<Rigidbody2D>().velocity.y);
    }
}

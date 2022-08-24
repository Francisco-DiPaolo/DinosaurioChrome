using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Movement
    public float speed;
    Rigidbody2D rb;

    // Jump
    bool isJumping;
    public float jumpForce;
    public float jump;
    public float maxJump;
    Vector2 jumpDirection = new Vector2(0, 2);

    // Dead
    bool isDead;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Movement();
        Jump();
    }

    /*void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");

        if(speed != 0)
        {
            transform.Translate(transform.right * inputX * speed * Time.deltaTime);
        }
    }*/

    void Jump()
    {
        if (Input.GetButton("Jump") && jump < maxJump)
        {
            rb.velocity = jumpDirection * jumpForce;
            jump++;
        }
    }

    void isGrounded()
    {
        jump = 0;
        isJumping = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded();
            Debug.Log(jump);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.eventIsDead?.Invoke();
            Debug.Log("Enemy");
        }
    }
}

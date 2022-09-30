using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float jump;
    public float maxJump;

    public bool isJumping;
    public bool isDead;

    Rigidbody2D rb;
    Vector2 jumpDirection = new Vector2(0, 2);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetButton("Jump"))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (jump < maxJump)
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
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.eventIsDead?.Invoke();
        }
    }
}

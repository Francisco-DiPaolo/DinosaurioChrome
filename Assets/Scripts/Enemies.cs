using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        //speed = 4f;
        speed = FindObjectOfType<SpawnManager>().speedEnemy;
    }

    void Update()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerDeadZone"))
        {
            Destroy(gameObject);
        }
    }
}

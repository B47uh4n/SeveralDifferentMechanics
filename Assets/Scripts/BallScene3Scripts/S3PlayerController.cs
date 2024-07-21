using UnityEngine;

public class S3PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float shootForce = 10f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
           // Shoot();
        }
    }

    void Shoot()
    {
        // Oyuncunun hýz vektörünü vuruþ yönü olarak al
        Vector2 shootDirection = GetComponent<Rigidbody2D>().velocity.normalized;

        // Topun (tag'i "Ball" olan nesnenin) Rigidbody2D bileþenine kuvvet uygula
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
        ballRigidbody.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
    }




}

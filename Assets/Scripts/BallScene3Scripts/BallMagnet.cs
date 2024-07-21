using UnityEngine;

public class BallMagnet : MonoBehaviour
{
    public float magnetForce = 10f; // Oyuncuya doðru çekme kuvveti

    void OnTriggerStay2D(Collider2D other)
    {
        // Eðer çarpýþan nesne "Ball" ise
        if (other.CompareTag("Ball"))
        {
            // Oyuncuya doðru bir kuvvet uygula
            Vector2 direction = (transform.position - other.transform.position).normalized;
            other.GetComponent<Rigidbody2D>().AddForce(direction * magnetForce);
        }
    }
}

using UnityEngine;

public class BallMagnet : MonoBehaviour
{
    public float magnetForce = 10f; // Oyuncuya do�ru �ekme kuvveti

    void OnTriggerStay2D(Collider2D other)
    {
        // E�er �arp��an nesne "Ball" ise
        if (other.CompareTag("Ball"))
        {
            // Oyuncuya do�ru bir kuvvet uygula
            Vector2 direction = (transform.position - other.transform.position).normalized;
            other.GetComponent<Rigidbody2D>().AddForce(direction * magnetForce);
        }
    }
}

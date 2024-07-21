using UnityEngine;

public class BallController : MonoBehaviour
{
    public float shootForce = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Topa bir kuvvet uygula (örneðin, ileri doðru)
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * shootForce, ForceMode2D.Impulse);
    }
}

using UnityEngine;

public class PlayerTrampoline : MonoBehaviour
{
    public float trampolineForce = 10f; // Uygulanacak kuvvet miktar�

    void Update()
    {
        // X tu�una bas�ld���nda trambolin etkisi uygula
        if (Input.GetKeyDown(KeyCode.X))
        {
            ApplyTrampolineForce();
        }
    }

    void ApplyTrampolineForce()
    {
        // Player nesnesinin etraf�nda bir alan olu�tur ve bu alanda bulunan her �eye bir kuvvet uygula
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f); // 2f, etkile�im alan�n�n yar��ap�

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Ball"))
            {
                // Topa kuvvet uygula
                Rigidbody2D ballRigidbody = collider.GetComponent<Rigidbody2D>();
                Vector2 direction = (collider.transform.position - transform.position).normalized;
                ballRigidbody.velocity = direction * trampolineForce;
            }
        }
    }

    // G�r�n�r olmas� i�in alan� g�stermek
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}

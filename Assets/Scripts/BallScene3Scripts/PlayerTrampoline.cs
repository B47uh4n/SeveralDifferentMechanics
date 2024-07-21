using UnityEngine;

public class PlayerTrampoline : MonoBehaviour
{
    public float trampolineForce = 10f; // Uygulanacak kuvvet miktarý

    void Update()
    {
        // X tuþuna basýldýðýnda trambolin etkisi uygula
        if (Input.GetKeyDown(KeyCode.X))
        {
            ApplyTrampolineForce();
        }
    }

    void ApplyTrampolineForce()
    {
        // Player nesnesinin etrafýnda bir alan oluþtur ve bu alanda bulunan her þeye bir kuvvet uygula
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f); // 2f, etkileþim alanýnýn yarýçapý

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

    // Görünür olmasý için alaný göstermek
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}

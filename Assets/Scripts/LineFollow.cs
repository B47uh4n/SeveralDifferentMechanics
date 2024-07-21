using System.Collections.Generic;
using UnityEngine;

public class LineFollow : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Rigidbody2D rb;
    private EdgeCollider2D edgeCollider;
    private List<Vector2> initialPoints;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        initialPoints = new List<Vector2>();
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            initialPoints.Add(lineRenderer.GetPosition(i));
        }
    }

    void Update()
    {
        // Rotasyon ve pozisyon güncellemesi
        Vector3 rbPosition = rb.position;
        Quaternion rbRotation = rb.transform.rotation;

        for (int i = 0; i < initialPoints.Count; i++)
        {
            // Pozisyonu ve rotasyonu güncelle
            Vector3 rotatedPoint = rbRotation * (Vector3)initialPoints[i];
            lineRenderer.SetPosition(i, rotatedPoint + rbPosition);
        }

        // Collider'larý debug çizgileriyle görselleþtir
        if (edgeCollider != null && edgeCollider.points.Length > 1)
        {
            for (int i = 0; i < edgeCollider.points.Length - 1; i++)
            {
                Vector2 start = edgeCollider.points[i];
                Vector2 end = edgeCollider.points[i + 1];
                Debug.DrawLine((Vector3)start + transform.position, (Vector3)end + transform.position, Color.green);
            }
        }
    }
}

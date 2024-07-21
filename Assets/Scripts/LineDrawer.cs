using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector2> points;
    private bool isDrawing = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red; // Kýrmýzý renk
        lineRenderer.endColor = Color.red; // Kýrmýzý renk
        points = new List<Vector2>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrawing();
        }

        if (isDrawing)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (points.Count == 0 || Vector2.Distance(points[points.Count - 1], mousePosition) > 0.1f)
            {
                points.Add(mousePosition);
                lineRenderer.positionCount = points.Count;
                lineRenderer.SetPosition(points.Count - 1, mousePosition);
            }
        }
    }

    void StartDrawing()
    {
        isDrawing = true;
        points.Clear();
        lineRenderer.positionCount = 0;
    }

    void EndDrawing()
    {
        isDrawing = false;

        if (points.Count > 1)
        {
            GameObject lineObject = new GameObject("Line");
            LineRenderer lr = lineObject.AddComponent<LineRenderer>();
            lr.positionCount = points.Count;
            lr.SetPositions(points.ConvertAll(p => (Vector3)p).ToArray());
            lr.startWidth = lineRenderer.startWidth;
            lr.endWidth = lineRenderer.endWidth;
            lr.material = lineRenderer.material; // Malzemeyi aktar
            lr.startColor = lineRenderer.startColor; // Rengi aktar
            lr.endColor = lineRenderer.endColor; // Rengi aktar

            Rigidbody2D rb = lineObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 1; // Yerçekimi ölçeðini ayarla
            rb.isKinematic = false; // Kinematik olmamalý

            EdgeCollider2D edgeCollider = lineObject.AddComponent<EdgeCollider2D>();
            edgeCollider.points = points.ToArray();

            // LineFollow scriptini ekle
            lineObject.AddComponent<LineFollow>();

            // Çizim tamamlandýktan sonra LineRenderer'ý temizle
            lineRenderer.positionCount = 0;
            points.Clear();
        }
    }
}

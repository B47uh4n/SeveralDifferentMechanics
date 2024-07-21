using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float panSpeed = 20f; // Kamera hareket h�z�
    public float zoomSpeed = 5f; // Kamera zoom h�z�
    public float minZoom = 2f; // Minimum zoom de�eri
    public float maxZoom = 20f; // Maksimum zoom de�eri

    private Vector3 initialPosition; // Kameran�n ba�lang�� pozisyonu
    private Vector3 startPanPosition; // Panning ba�lang�� pozisyonu

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        HandlePanning();
        HandleZoom();
    }

    private void HandlePanning()
    {
        if (Input.GetMouseButtonDown(1))
        {
            startPanPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 direction = startPanPosition - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
    }

    private void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float size = Camera.main.orthographicSize;
        size -= scroll * zoomSpeed;
        size = Mathf.Clamp(size, minZoom, maxZoom);
        Camera.main.orthographicSize = size;
    }
}

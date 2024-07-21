using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float panSpeed = 20f; // Kamera hareket hýzý
    public float zoomSpeed = 5f; // Kamera zoom hýzý
    public float minZoom = 2f; // Minimum zoom deðeri
    public float maxZoom = 20f; // Maksimum zoom deðeri

    private Vector3 initialPosition; // Kameranýn baþlangýç pozisyonu
    private Vector3 startPanPosition; // Panning baþlangýç pozisyonu

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

using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f; // Karakterin hareket h�z�
    private Vector3 targetPosition; // Hedef pozisyon
    private bool isMoving = false; // Hareket kontrol�

    void Start()
    {
        targetPosition = transform.position; // Ba�lang��ta hedef pozisyon karakterin mevcut pozisyonu
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Mouse sol t�k kontrol�
        {
            SetTargetPosition();
        }

        if (isMoving)
        {
            MoveCharacter();
        }
    }

    void SetTargetPosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Mouse pozisyonunu d�nya pozisyonuna �evir
        targetPosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z); // Z eksenini sabit tut
        isMoving = true;
    }

    void MoveCharacter()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); // Karakteri hedef pozisyona hareket ettir

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f) // Hedefe ula��ld���nda
        {
            isMoving = false;
        }
    }
}

using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f; // Karakterin hareket hýzý
    private Vector3 targetPosition; // Hedef pozisyon
    private bool isMoving = false; // Hareket kontrolü

    void Start()
    {
        targetPosition = transform.position; // Baþlangýçta hedef pozisyon karakterin mevcut pozisyonu
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Mouse sol týk kontrolü
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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Mouse pozisyonunu dünya pozisyonuna çevir
        targetPosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z); // Z eksenini sabit tut
        isMoving = true;
    }

    void MoveCharacter()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); // Karakteri hedef pozisyona hareket ettir

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f) // Hedefe ulaþýldýðýnda
        {
            isMoving = false;
        }
    }
}

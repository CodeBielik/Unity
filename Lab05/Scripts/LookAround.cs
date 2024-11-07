using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // Ruch wok� osi Y b�dzie wykonywany na obiekcie gracza (Transform)
    public Transform player;

    public float sensitivity = 200f;

    // Zmienna do �ledzenia aktualnej rotacji wok� osi X (g�ra-d�)
    private float xRotation = 0f;

    void Start()
    {
        // Zablokowanie kursora na �rodku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Pobieramy warto�ci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Wykonujemy rotacj� wok� osi Y (obr�t postaci)
        player.Rotate(Vector3.up * mouseXMove);

        // Aktualizujemy rotacj� wok� osi X (obr�t kamery g�ra-d�)
        xRotation -= mouseYMove;  // Odwr�cenie warto�ci dla osi X, aby unikn�� efektu "mouse inverse"

        // Ograniczamy rotacj� kamery w zakresie -90 do +90 stopni
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Zastosowanie rotacji kamery wok� osi X
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}

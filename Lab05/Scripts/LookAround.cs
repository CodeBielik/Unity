using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // Ruch wokó³ osi Y bêdzie wykonywany na obiekcie gracza (Transform)
    public Transform player;

    public float sensitivity = 200f;

    // Zmienna do œledzenia aktualnej rotacji wokó³ osi X (góra-dó³)
    private float xRotation = 0f;

    void Start()
    {
        // Zablokowanie kursora na œrodku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Pobieramy wartoœci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Wykonujemy rotacjê wokó³ osi Y (obrót postaci)
        player.Rotate(Vector3.up * mouseXMove);

        // Aktualizujemy rotacjê wokó³ osi X (obrót kamery góra-dó³)
        xRotation -= mouseYMove;  // Odwrócenie wartoœci dla osi X, aby unikn¹æ efektu "mouse inverse"

        // Ograniczamy rotacjê kamery w zakresie -90 do +90 stopni
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Zastosowanie rotacji kamery wokó³ osi X
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}

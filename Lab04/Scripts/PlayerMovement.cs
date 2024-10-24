using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Pr�dko�� poruszania si� gracza

    void Update()
    {
        // Odczytaj dane wej�ciowe z klawiatury
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // A/D lub strza�ki w lewo/prawo
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // W/S lub strza�ki w g�r�/d�

        // Przesu� gracza
        transform.Translate(moveX, 0, moveZ);
    }
}

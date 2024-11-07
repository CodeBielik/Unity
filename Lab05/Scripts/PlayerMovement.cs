using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Prêdkoœæ poruszania siê gracza

    void Update()
    {
        // Odczytaj dane wejœciowe z klawiatury
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // A/D lub strza³ki w lewo/prawo
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // W/S lub strza³ki w górê/dó³

        // Przesuñ gracza
        transform.Translate(moveX, 0, moveZ);
    }
}

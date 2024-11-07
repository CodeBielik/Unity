using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Sprawdzenie, czy obiekt, z którym gracz koliduje, ma tag "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Kontakt z przeszkod¹!");
        }
    }
}

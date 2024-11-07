using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float launchMultiplier = 3f;
    public float jumpHeight = 3f;

    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzenie, czy obiekt to gracz
        if (other.CompareTag("Player"))
        {
            // Pobieranie skryptu gracza
            PlayerMovement2 playerMovement = other.GetComponent<PlayerMovement2>();

            if (playerMovement != null)
            {
                float launchHeight = jumpHeight * launchMultiplier;
                playerMovement.velocity.y = Mathf.Sqrt(launchHeight * -2f * playerMovement.gravity);

            }
            else
            {
                Debug.LogWarning("Brak skryptu PlayerMovement2 na graczu!");
            }
        }
    }
}

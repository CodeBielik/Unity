using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform door;           // Obiekt drzwi
    public Vector3 closedPosition;   // Pozycja zamkni�ta drzwi
    public Vector3 openPosition;     // Pozycja otwarta drzwi
    public float speed = 2f;         // Pr�dko�� przesuwania drzwi

    private bool isPlayerInZone = false; // Flaga sprawdzaj�ca, czy gracz jest w strefie

    void Start()
    {
        // Ustawienie drzwi w pozycji zamkni�tej na starcie
        if (door != null)
        {
            door.localPosition = closedPosition;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Sprawdzenie, czy gracz wszed� do strefy
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true; // Ustawienie flagi na true, aby otworzy� drzwi
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Sprawdzenie, czy gracz opu�ci� stref�
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false; // Ustawienie flagi na false, aby zamkn�� drzwi
        }
    }

    void Update()
    {
        // Sprawdzanie, czy drzwi maj� si� otwiera� czy zamyka�
        if (door != null)
        {
            // W zale�no�ci od flagi przesuni�cie drzwi do otwartej lub zamkni�tej pozycji
            Vector3 targetPosition = isPlayerInZone ? openPosition : closedPosition;
            door.localPosition = Vector3.MoveTowards(door.localPosition, targetPosition, speed * Time.deltaTime);
        }
    }
}

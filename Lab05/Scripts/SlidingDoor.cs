using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform door;           // Obiekt drzwi
    public Vector3 closedPosition;   // Pozycja zamkniêta drzwi
    public Vector3 openPosition;     // Pozycja otwarta drzwi
    public float speed = 2f;         // Prêdkoœæ przesuwania drzwi

    private bool isPlayerInZone = false; // Flaga sprawdzaj¹ca, czy gracz jest w strefie

    void Start()
    {
        // Ustawienie drzwi w pozycji zamkniêtej na starcie
        if (door != null)
        {
            door.localPosition = closedPosition;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Sprawdzenie, czy gracz wszed³ do strefy
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true; // Ustawienie flagi na true, aby otworzyæ drzwi
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Sprawdzenie, czy gracz opuœci³ strefê
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false; // Ustawienie flagi na false, aby zamkn¹æ drzwi
        }
    }

    void Update()
    {
        // Sprawdzanie, czy drzwi maj¹ siê otwieraæ czy zamykaæ
        if (door != null)
        {
            // W zale¿noœci od flagi przesuniêcie drzwi do otwartej lub zamkniêtej pozycji
            Vector3 targetPosition = isPlayerInZone ? openPosition : closedPosition;
            door.localPosition = Vector3.MoveTowards(door.localPosition, targetPosition, speed * Time.deltaTime);
        }
    }
}

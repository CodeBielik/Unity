using UnityEngine;
using System.Collections;

public class MoveInSquare : MonoBehaviour
{
    public float speed = 2f; // Pr�dko�� ruchu
    public float pauseTime = 1f; // Czas pauzy
    private Vector3 startPosition;
    private bool isMoving = true; // Flaga sprawdzaj�ca, czy obiekt si� porusza
    private int currentCorner = 0; // Indeks aktualnego wierzcho�ka
    private Vector3[] corners; // Wierzcho�ki kwadratu

    void Start()
    {
        startPosition = transform.position; // Zapisz pocz�tkow� pozycj�
        corners = new Vector3[4]; // Inicjalizuj tablic� wierzcho�k�w
        corners[0] = startPosition; // Wierzcho�ek 1
        corners[1] = startPosition + new Vector3(10, 0, 0); // Wierzcho�ek 2
        corners[2] = startPosition + new Vector3(10, 0, 10); // Wierzcho�ek 3
        corners[3] = startPosition + new Vector3(0, 0, 10); // Wierzcho�ek 4
    }

    void Update()
    {
        if (isMoving)
        {
            float moveDistance = speed * Time.deltaTime;
            Vector3 targetPosition = corners[currentCorner];

            // Ruch w stron� aktualnego wierzcho�ka
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveDistance);

            // Sprawd�, czy osi�gni�to aktualny wierzcho�ek
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                StartCoroutine(PauseAndTurn()); // Rozpocznij korutyn�
            }
        }
    }

    private IEnumerator PauseAndTurn()
    {
        isMoving = false; // Zatrzymaj ruch
        yield return new WaitForSeconds(pauseTime); // Pauza

        // Zmie� kierunek na nast�pny wierzcho�ek
        currentCorner = (currentCorner + 1) % corners.Length;

        // Wykonaj obr�t o 90 stopni
        transform.Rotate(0, 90, 0);

        isMoving = true; // Wzn�w ruch
    }
}

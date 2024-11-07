using UnityEngine;
using System.Collections;

public class MoveInSquare : MonoBehaviour
{
    public float speed = 2f; // Prêdkoœæ ruchu
    public float pauseTime = 1f; // Czas pauzy
    private Vector3 startPosition;
    private bool isMoving = true; // Flaga sprawdzaj¹ca, czy obiekt siê porusza
    private int currentCorner = 0; // Indeks aktualnego wierzcho³ka
    private Vector3[] corners; // Wierzcho³ki kwadratu

    void Start()
    {
        startPosition = transform.position; // Zapisz pocz¹tkow¹ pozycjê
        corners = new Vector3[4]; // Inicjalizuj tablicê wierzcho³ków
        corners[0] = startPosition; // Wierzcho³ek 1
        corners[1] = startPosition + new Vector3(10, 0, 0); // Wierzcho³ek 2
        corners[2] = startPosition + new Vector3(10, 0, 10); // Wierzcho³ek 3
        corners[3] = startPosition + new Vector3(0, 0, 10); // Wierzcho³ek 4
    }

    void Update()
    {
        if (isMoving)
        {
            float moveDistance = speed * Time.deltaTime;
            Vector3 targetPosition = corners[currentCorner];

            // Ruch w stronê aktualnego wierzcho³ka
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveDistance);

            // SprawdŸ, czy osi¹gniêto aktualny wierzcho³ek
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                StartCoroutine(PauseAndTurn()); // Rozpocznij korutynê
            }
        }
    }

    private IEnumerator PauseAndTurn()
    {
        isMoving = false; // Zatrzymaj ruch
        yield return new WaitForSeconds(pauseTime); // Pauza

        // Zmieñ kierunek na nastêpny wierzcho³ek
        currentCorner = (currentCorner + 1) % corners.Length;

        // Wykonaj obrót o 90 stopni
        transform.Rotate(0, 90, 0);

        isMoving = true; // Wznów ruch
    }
}

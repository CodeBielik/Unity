using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour
{
    public float speed = 2f; // Pr�dko�� ruchu
    public float pauseTime = 1f; // Czas pauzy
    private Vector3 startPosition;
    private bool isMoving = true; // Flaga sprawdzaj�ca, czy obiekt si� porusza
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position; // Zapisz pocz�tkow� pozycj�
    }

    void Update()
    {
        if (isMoving)
        {
            float moveDistance = speed * Time.deltaTime;

            if (movingRight)
            {
                // Przesuwaj w prawo
                transform.Translate(moveDistance, 0, 0);

                // Sprawd�, czy osi�gni�to x = 10
                if (transform.position.x >= startPosition.x + 10)
                {
                    movingRight = false; // Zmie� kierunek
                    transform.position = new Vector3(startPosition.x + 10, transform.position.y, transform.position.z); // Ustaw dok�adnie na 10
                    StartCoroutine(PauseAndReturn()); // Rozpocznij korutyn�
                }
            }
            else
            {
                // Przesuwaj w lewo
                transform.Translate(-moveDistance, 0, 0);

                // Sprawd�, czy wr�cono do pozycji startowej
                if (transform.position.x <= startPosition.x)
                {
                    movingRight = true; // Zmie� kierunek
                    transform.position = startPosition; // Ustaw dok�adnie na pocz�tkowej pozycji
                    StartCoroutine(PauseAndReturn()); // Rozpocznij korutyn�
                }
            }
        }
    }

    private IEnumerator PauseAndReturn()
    {
        isMoving = false; // Zatrzymaj ruch
        yield return new WaitForSeconds(pauseTime); // Pauza
        isMoving = true; // Wzn�w ruch
    }
}

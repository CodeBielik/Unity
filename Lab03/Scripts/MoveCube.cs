using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour
{
    public float speed = 2f; // Prêdkoœæ ruchu
    public float pauseTime = 1f; // Czas pauzy
    private Vector3 startPosition;
    private bool isMoving = true; // Flaga sprawdzaj¹ca, czy obiekt siê porusza
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position; // Zapisz pocz¹tkow¹ pozycjê
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

                // SprawdŸ, czy osi¹gniêto x = 10
                if (transform.position.x >= startPosition.x + 10)
                {
                    movingRight = false; // Zmieñ kierunek
                    transform.position = new Vector3(startPosition.x + 10, transform.position.y, transform.position.z); // Ustaw dok³adnie na 10
                    StartCoroutine(PauseAndReturn()); // Rozpocznij korutynê
                }
            }
            else
            {
                // Przesuwaj w lewo
                transform.Translate(-moveDistance, 0, 0);

                // SprawdŸ, czy wrócono do pozycji startowej
                if (transform.position.x <= startPosition.x)
                {
                    movingRight = true; // Zmieñ kierunek
                    transform.position = startPosition; // Ustaw dok³adnie na pocz¹tkowej pozycji
                    StartCoroutine(PauseAndReturn()); // Rozpocznij korutynê
                }
            }
        }
    }

    private IEnumerator PauseAndReturn()
    {
        isMoving = false; // Zatrzymaj ruch
        yield return new WaitForSeconds(pauseTime); // Pauza
        isMoving = true; // Wznów ruch
    }
}

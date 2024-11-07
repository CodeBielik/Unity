using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 targetPosition; // Wsp�rz�dne punktu docelowego
    public float speed = 2f;       // Pr�dko�� ruchu

    private Vector3 startPosition;
    private bool isMoving = false;
    private bool movingToTarget = true;
    private bool returningToStart = false;

    void Start()
    {
        startPosition = transform.position; // Zapisz pozycj� startow�
    }

    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        float step = speed * Time.deltaTime;

        if (isMoving)
        {
            if (movingToTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

                if (transform.position == targetPosition)
                {
                    movingToTarget = false; // Zmiana kierunku
                }
            }
            else if (returningToStart)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, step);

                if (transform.position == startPosition)
                {
                    // Platforma zatrzymuje si� i czeka na gracza
                    returningToStart = false;
                    isMoving = false;
                    movingToTarget = true;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isMoving = true;          // Rozpocznij ruch
            returningToStart = false;  // Platforma przestaje wraca� do pocz�tku
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            returningToStart = true;   // Uruchom powr�t do pozycji pocz�tkowej
            isMoving = true;
        }
    }
}

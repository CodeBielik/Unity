using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 targetPosition; // Wspó³rzêdne punktu docelowego
    public float speed = 2f;       // Prêdkoœæ ruchu

    private Vector3 startPosition;
    private bool isMoving = false;
    private bool movingToTarget = true;
    private bool returningToStart = false;

    void Start()
    {
        startPosition = transform.position; // Zapisz pozycjê startow¹
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
                    // Platforma zatrzymuje siê i czeka na gracza
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
            returningToStart = false;  // Platforma przestaje wracaæ do pocz¹tku
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            returningToStart = true;   // Uruchom powrót do pozycji pocz¹tkowej
            isMoving = true;
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

public class MovingPlatform2 : MonoBehaviour
{
    [Tooltip("Lista punkt�w, do kt�rych platforma si� przemieszcza")]
    public List<Vector3> waypoints = new List<Vector3>();

    public float speed = 3f;             // Pr�dko�� platformy
    private int currentWaypointIndex = 0; // Indeks aktualnego punktu docelowego
    private bool isReversing = false;     // Flaga okre�laj�ca, czy platforma zawraca

    void Start()
    {
        // Sprawdzamy, czy s� punkty do przemieszczania
        if (waypoints.Count > 0)
        {
            // Ustawiamy platform� na pierwszym punkcie
            transform.position = waypoints[0];
        }
        else
        {
            Debug.LogWarning("Waypoint list is empty. Please add waypoints in the Inspector.");
        }
    }

    void Update()
    {
        if (waypoints.Count == 0)
            return;

        // Pobieramy obecny punkt docelowy
        Vector3 targetPosition = waypoints[currentWaypointIndex];

        // Przemieszczamy platform� w kierunku aktualnego punktu docelowego
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Sprawdzamy, czy platforma dotar�a do punktu
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Zmieniamy kierunek na przeciwny, je�li osi�gniemy koniec listy lub pocz�tek
            if (!isReversing && currentWaypointIndex == waypoints.Count - 1)
            {
                isReversing = true;
            }
            else if (isReversing && currentWaypointIndex == 0)
            {
                isReversing = false;
            }

            // Przechodzimy do nast�pnego punktu lub cofamy si�
            currentWaypointIndex = isReversing ? currentWaypointIndex - 1 : currentWaypointIndex + 1;
        }
    }
}

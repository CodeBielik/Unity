using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public Transform target; // Obiekt, kt�ry ma by� �ledzony
    public float smoothTime = 0.3f; // Czas wyg�adzania
    private Vector3 velocity = Vector3.zero; // Przechowuje pr�dko��

    void Update()
    {
        // U�yj SmoothDamp do wyg�adzenia ruchu
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);

        // U�yj Lerp do przetestowania
        if (Input.GetKeyDown(KeyCode.L)) // Naci�nij L, aby u�y� Lerp
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.1f);
        }
    }
}

using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public Transform target; // Obiekt, który ma byæ œledzony
    public float smoothTime = 0.3f; // Czas wyg³adzania
    private Vector3 velocity = Vector3.zero; // Przechowuje prêdkoœæ

    void Update()
    {
        // U¿yj SmoothDamp do wyg³adzenia ruchu
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);

        // U¿yj Lerp do przetestowania
        if (Input.GetKeyDown(KeyCode.L)) // Naciœnij L, aby u¿yæ Lerp
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.1f);
        }
    }
}

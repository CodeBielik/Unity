using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // Prefab sze�cianu
    public int numberOfCubes = 10; // Liczba generowanych sze�cian�w
    public float spacing = 1.5f; // Odst�p mi�dzy sze�cianami
    private HashSet<Vector3> positions = new HashSet<Vector3>(); // Przechowuje zaj�te pozycje

    void Start()
    {
        GenerateCubes();
    }

    void GenerateCubes()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 position;

        do
        {
            // Generuj losowe pozycje w zakresie p�aszczyzny z uwzgl�dnieniem odst�pu
            position = new Vector3(Random.Range(-5f + spacing / 2, 5f - spacing / 2),
                                   0.5f,
                                   Random.Range(-5f + spacing / 2, 5f - spacing / 2));
        } while (IsPositionOccupied(position));

        positions.Add(position);
        return position;
    }

    bool IsPositionOccupied(Vector3 position)
    {
        // Sprawd�, czy w pobli�u s� inne sze�ciany (uwzgl�dniaj�c odst�p)
        foreach (Vector3 pos in positions)
        {
            if (Vector3.Distance(pos, position) < spacing)
            {
                return true; // Pozycja jest zaj�ta
            }
        }
        return false; // Pozycja jest wolna
    }
}

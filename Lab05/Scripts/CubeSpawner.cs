using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // Prefab szeœcianu
    public int numberOfCubes = 10; // Liczba generowanych szeœcianów
    public float spacing = 1.5f; // Odstêp miêdzy szeœcianami
    private HashSet<Vector3> positions = new HashSet<Vector3>(); // Przechowuje zajête pozycje

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
            // Generuj losowe pozycje w zakresie p³aszczyzny z uwzglêdnieniem odstêpu
            position = new Vector3(Random.Range(-5f + spacing / 2, 5f - spacing / 2),
                                   0.5f,
                                   Random.Range(-5f + spacing / 2, 5f - spacing / 2));
        } while (IsPositionOccupied(position));

        positions.Add(position);
        return position;
    }

    bool IsPositionOccupied(Vector3 position)
    {
        // SprawdŸ, czy w pobli¿u s¹ inne szeœciany (uwzglêdniaj¹c odstêp)
        foreach (Vector3 pos in positions)
        {
            if (Vector3.Distance(pos, position) < spacing)
            {
                return true; // Pozycja jest zajêta
            }
        }
        return false; // Pozycja jest wolna
    }
}

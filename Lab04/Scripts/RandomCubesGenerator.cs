using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    // Obiekt do generowania
    public GameObject block;

    // Liczba losowych obiektów do wygenerowania, okreœlona w inspektorze
    public int numberOfObjects = 10;

    // Materia³y do losowego przypisywania
    public Material[] materials;

    void Start()
    {
        // Pobranie rozmiarów platformy (obiekt, do którego przypisany jest skrypt)
        Bounds platformBounds = GetComponent<Renderer>().bounds;

        // Generowanie losowych pozycji w zakresie platformy
        List<float> pozycje_x = new List<float>();
        List<float> pozycje_z = new List<float>();

        for (int i = 0; i < numberOfObjects; i++)
        {
            float randomX = UnityEngine.Random.Range(platformBounds.min.x, platformBounds.max.x);
            float randomZ = UnityEngine.Random.Range(platformBounds.min.z, platformBounds.max.z);
            pozycje_x.Add(randomX);
            pozycje_z.Add(randomZ);
        }

        for (int i = 0; i < numberOfObjects; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 0.5f, pozycje_z[i]));
        }

        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }

        // Uruchamiamy coroutine do generowania obiektów
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        // Nic nie zmieniamy w Update na ten moment
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("Wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(this.block, pos, Quaternion.identity);

            // Losowe przypisanie materia³u
            Renderer renderer = newBlock.GetComponent<Renderer>();
            if (renderer != null && materials.Length > 0)
            {
                Material randomMaterial = materials[UnityEngine.Random.Range(0, materials.Length)];
                renderer.material = randomMaterial;
            }

            yield return new WaitForSeconds(this.delay);
        }

        // Zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}

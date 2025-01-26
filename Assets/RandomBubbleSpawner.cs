using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [Header("Objeto a spawnear")]
    public GameObject prefab;

    [Header("Intervalo de spawn (segundos)")]
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    // Referencia al último objeto instanciado
    private GameObject currentSpawned;

    public Sprite[] bubbleFaces;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // Espera un tiempo aleatorio entre minSpawnTime y maxSpawnTime
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            // Solo instancia un nuevo objeto si el anterior ya no existe
            if (currentSpawned == null)
            {
                currentSpawned = Instantiate(prefab, transform.position, transform.rotation);

                currentSpawned.GetComponent<SpriteRenderer>().sprite = bubbleFaces[Random.Range(0, bubbleFaces.Length)]; 
            }
        }
    }
}

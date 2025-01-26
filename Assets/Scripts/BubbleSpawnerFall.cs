using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BubbleSpawnerFall : MonoBehaviour
{
    public float minSpawnerX; 
    public float maxSpawnerX;

    public GameObject bubbleGO;

    private void Start()
    {
        InvokeRepeating("SpawnBubble", 2, 0.2f); 
    }

    void SpawnBubble()
    {
        float randomSpawnYNumber = Random.Range(minSpawnerX,maxSpawnerX);
        Vector3 spawnVector = new Vector3(transform.position.x + randomSpawnYNumber, transform.position.y, 0);

        GameObject bubbleClone = Instantiate(bubbleGO, spawnVector, Quaternion.identity); 
    }
}

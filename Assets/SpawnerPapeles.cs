using UnityEngine;

public class SpawnerPapeles : MonoBehaviour
{
    public GameObject papelesGO; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPapeles();    
    }

    public void SpawnPapeles()
    {
        GameObject papelClon = Instantiate(papelesGO, transform.position, Quaternion.identity);
    }

}

using UnityEngine;

public class PapelBurbujaController : MonoBehaviour
{
    public Sprite[] bubbleFaces; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = bubbleFaces[Random.Range(0, bubbleFaces.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

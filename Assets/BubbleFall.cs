using UnityEngine;

public class BubbleFall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomeScaleGenerator = Random.Range(0.2f, 0.5f);

        transform.localScale = transform.localScale*randomeScaleGenerator; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

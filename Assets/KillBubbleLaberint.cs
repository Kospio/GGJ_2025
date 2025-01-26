using UnityEngine;

public class KillBubbleLaberint : MonoBehaviour
{
    MinigameManager minigameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minigameManager = FindFirstObjectByType<MinigameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Perro"))
        {
            minigameManager.ExplodeBubble();
            Destroy(this.gameObject);
        }
        
    }
}

using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public int speedMovement;
    MinigameManager manager;

    private void Start()
    {
        manager = GameManager.FindFirstObjectByType<MinigameManager>();
        Invoke("Die", 3); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speedMovement * Time.deltaTime;
    }
    
    void Die()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BubbleFall"))
        {
            manager.ExplodeBubble();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public int speedMovement;

    private void Start()
    {
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
}

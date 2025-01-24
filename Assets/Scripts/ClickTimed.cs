using UnityEngine;
using UnityEngine.InputSystem;

public class ClickTimed : MonoBehaviour
{
    float scaleFactor;

    //No funciona el inspector
    public float maximumScale;

    public float scaleSpeed;
    public float scaleSum;

    GameObject scaledObject;
    GameManager gameManager;

    private void Start()
    {
        maximumScale = 3; 

        scaledObject = this.gameObject;
        gameManager = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            scaleFactor += scaleSum;

            if (scaleFactor >= maximumScale)
            {
                ExplodeBubble();
            }
        }

        if (scaleFactor > 0)
        {
            if(scaleFactor - Time.deltaTime * scaleSpeed < 0)
            {
                scaleFactor = 0; 
            }

            scaleFactor = scaleFactor - Time.deltaTime * scaleSpeed;
        }

        scaledObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
    }

    void ExplodeBubble()
    {
        gameManager.BubblesKilled++;

        Debug.Log(gameManager.BubblesKilled); 

        Instantiate(scaledObject);

        scaleFactor = 0; 

        scaledObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);

        Destroy(this.gameObject);
    }
}

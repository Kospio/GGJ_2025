using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class ClickTimed : MonoBehaviour
{
    float scaleFactor;

    public float maximumScale;

    public float scaleSpeed;
    public float scaleSum;

    GameObject scaledObject;
    MinigameManager minigameManager;

    private void Start()
    {
        scaledObject = this.gameObject;
        minigameManager = FindFirstObjectByType<MinigameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(minigameManager.timeToStart <= 0)
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
                if (scaleFactor - Time.deltaTime * scaleSpeed < 0)
                {
                    scaleFactor = 0;
                }

                scaleFactor = scaleFactor - Time.deltaTime * scaleSpeed;
            }

            scaledObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
        }
        
    }

    void ExplodeBubble()
    {
        minigameManager.ExplodeBubble();

        Instantiate(scaledObject); 
        Destroy(this.gameObject);
    }
}

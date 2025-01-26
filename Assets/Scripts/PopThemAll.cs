using System.Collections;
using UnityEngine;

public class PopThemAll : MonoBehaviour
{
    MinigameManager minigameManager;
    public Sprite[] animationBubblesExplode;

    GameObject targetBubbleGO; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minigameManager = FindFirstObjectByType<MinigameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && minigameManager.timeLeft > 0)
        {
            // Convierte la posición del mouse a coordenadas del mundo
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Lanza un rayo en la posición donde se ha hecho clic
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Verifica si ha colisionado con algo
            if (hit.collider != null)
            {
                // Comprueba si el objeto colisionado tiene la etiqueta "BurbujaPapel"
                if (hit.collider.CompareTag("BurbujaFinal"))
                {
                    targetBubbleGO = hit.collider.gameObject;
                    StartCoroutine(PopAnimation()); 
                    minigameManager.ExplodeBubble();
                }
            }
        }
    }

    IEnumerator PopAnimation()
    {
        for (int i = 0; i < animationBubblesExplode.Length; i++)
        {
            targetBubbleGO.gameObject.GetComponent<SpriteRenderer>().sprite = animationBubblesExplode[i];
            yield return new WaitForSeconds(0.1f);
        }
        
        Destroy(targetBubbleGO);
    }
}

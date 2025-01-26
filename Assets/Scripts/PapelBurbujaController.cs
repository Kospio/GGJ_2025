using System.Collections;
using UnityEngine;

public class PapelBurbujaController : MonoBehaviour
{
    public Sprite[] bubbleFaces;
    public Sprite deadSprite;

    Transform[] bubblesGOs;

    int bubblesExploded;
    MinigameManager minigameManager;

    // Posiciones para moverse
    public Vector2 InitialPosition;
    public Vector2 MediumPosition;
    public Vector2 FinalPosition;

    // Velocidad de movimiento (asígnale un valor en el Inspector)
    public float movementSpeed = 1f;

    // Factor de interpolación
    private float t = 0f;

    SpawnerPapeles spawnerScript; 

    void Start()
    {
        spawnerScript = FindFirstObjectByType<SpawnerPapeles>();
        minigameManager = FindFirstObjectByType<MinigameManager>();
        bubblesGOs = GetComponentsInChildren<Transform>();

        // Asigna una cara aleatoria a cada burbuja
        for (int i = 1; i < bubblesGOs.Length; i++)
        {
            bubblesGOs[i].gameObject.GetComponent<SpriteRenderer>().sprite
                = bubbleFaces[Random.Range(0, bubbleFaces.Length)];
        }

        transform.position = InitialPosition;

        StartCoroutine(FirstMovement()); 
    }

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
                if (hit.collider.CompareTag("BurbujaPapel"))
                {
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = deadSprite;

                    bubblesExploded++;
                    minigameManager.ExplodeBubble();

                    // Si todas las burbujas han sido explotadas, inicia la corrutina de movimiento final
                    if (bubblesExploded == bubblesGOs.Length -1)
                    {
                        StartCoroutine(FinalMove());
                    }
                }
            }
        }
    }

    IEnumerator FirstMovement()
    {
        // Reiniciamos 't'
        t = 0f;

        // Iniciamos la posición en el punto inicial
        transform.position = InitialPosition;

        // Mientras 't' sea menor que 1, seguimos interpolando
        while (t < 1f)
        {
            t += Time.deltaTime * movementSpeed;        // Incrementamos 't'
            transform.position = Vector2.Lerp(InitialPosition, MediumPosition, t);

            // Esperamos al siguiente frame antes de continuar
            yield return null;
        }

        // Ajuste final: nos aseguramos de que la posición sea exactamente MediumPosition
        transform.position = MediumPosition;
    }

    IEnumerator FinalMove()
    {
        // Reseteamos t y establecemos la posición de inicio a MediumPosition
        t = 0f;
        transform.position = MediumPosition;

        // Mientras t no alcance 1, seguimos interpolando
        while (t < 1f)
        {
            // Incrementamos t en función de la velocidad y el tiempo transcurrido
            t += Time.deltaTime * movementSpeed;

            // Interpolamos la posición entre MediumPosition (t=0) y FinalPosition (t=1)
            transform.position = Vector2.Lerp(MediumPosition, FinalPosition, t);

            // Esperamos hasta el siguiente frame
            yield return null;
        }

        // Ajuste final para asegurar que la posición sea exactamente la final
        transform.position = FinalPosition;

        spawnerScript.SpawnPapeles(); 

        Destroy(gameObject);
    }
}

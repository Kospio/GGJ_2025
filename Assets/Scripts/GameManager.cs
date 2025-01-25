using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int BubblesKilled;

    // Instancia estática del Singleton
    private static GameManager instance;

    // Propiedad pública para acceder a la instancia
    public static GameManager Instance
    {
        get
        {
            // Si la instancia es nula, busca una existente o crea una nueva
            if (instance == null)
            {
                instance = FindFirstObjectByType<GameManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<GameManager>();
                    singletonObject.name = typeof(GameManager).ToString() + " (Singleton)";
                }
            }
            return instance;
        }
    }

    // Método Awake para asegurar que solo haya una instancia
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}

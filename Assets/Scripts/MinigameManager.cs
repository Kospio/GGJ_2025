using System.Collections;
using UnityEngine.UI; 
using Unity.VisualScripting;
using UnityEngine;
using TMPro; 

public class MinigameManager : MonoBehaviour
{
    GameManager gameManager;

    public float timeMaxLevel;
    
    int bubblesExplodedLocal;
    float fadeDuration = 1f;

    [HideInInspector]
    public Image fadeImage;

    [SerializeField]
    TextMeshProUGUI countdownText;
    
    //public TextMeshPro bubblesExplodedText;

    [HideInInspector]
    public float timeToStart;
    SceneTransitionManager transitionManager;

    public string nextSceneToLoad;


    private void Start()
    {
        //Siempre un countdown de 3 segundos
        timeToStart = 3;
        gameManager = FindFirstObjectByType<GameManager>();
        transitionManager = FindFirstObjectByType<SceneTransitionManager>();

        countdownText = GameObject.FindGameObjectWithTag("CountDownText").gameObject.GetComponent<TextMeshProUGUI>();
        fadeImage = GameObject.FindGameObjectWithTag("CountDownPanel").gameObject.GetComponent<Image>();

        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        yield return new WaitForSeconds(1f);
        timeToStart--;
        countdownText.text = timeToStart.ToString(); 

        yield return new WaitForSeconds(1f);
        timeToStart--;
        countdownText.text = timeToStart.ToString();
        StartCoroutine(Fade(1f, 0f));

        yield return new WaitForSeconds(1f);
        timeToStart--;
        Destroy(countdownText.gameObject);

        //PRUEBA BORRAR
        LoadNextScene(nextSceneToLoad);
    }

    public void ExplodeBubble()
    {
        bubblesExplodedLocal++;
        gameManager.BubblesKilled++; 
    }

    void LoadNextScene(string localNameNextScene)
    {
        transitionManager.FadeToScene(localNameNextScene);
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;

        // Si no se ha asignado la imagen, evitar errores
        if (fadeImage == null)
        {
            yield break;
        }

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);

            // Asigna el nuevo color con el alpha interpolado
            Color newColor = fadeImage.color;
            newColor.a = alpha;
            fadeImage.color = newColor;

            yield return null;
        }

        // Asegurar el alpha final exacto
        Color finalColor = fadeImage.color;
        finalColor.a = endAlpha;
        fadeImage.color = finalColor;
    }
}

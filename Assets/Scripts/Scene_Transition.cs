using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class SceneTransitionManager : MonoBehaviour
{
    [Header("Tiempo que durará el fundido (en segundos)")]
    public float fadeDuration = 1f;

    [Header("Imagen UI para el efecto de transición")]
    Image fadeImage;

    GameObject canvasPanel; 
    GameObject timerImage;
    GameObject BubblesExplodedLocal;

    private void Start()
    {
        canvasPanel = GameObject.FindGameObjectWithTag("CountDownPanel");
        timerImage = GameObject.FindGameObjectWithTag("TimerImage");
        BubblesExplodedLocal = GameObject.FindGameObjectWithTag("BubblesExplodedLocal");
        fadeImage = canvasPanel.GetComponent<Image>();

        //canvasPanel.gameObject.SetActive(false);
        timerImage.gameObject.SetActive(false);
        BubblesExplodedLocal.gameObject.SetActive(false);
    }

    /// <summary>
    /// Llama a esta función para hacer la transición a otra escena con fundido.
    /// </summary>
    /// <param name="sceneName">Nombre de la escena a cargar</param>
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOutIn(sceneName));
    }

    private IEnumerator FadeOutIn(string sceneName)
    {
        // Fase 1: Fundir de transparente a negro
        yield return StartCoroutine(Fade(0f, 1f));

        //canvasPanel.gameObject.SetActive(false);
        timerImage.gameObject.SetActive(false);
        BubblesExplodedLocal.gameObject.SetActive(false);

        // Cargar nueva escena
        SceneManager.LoadScene(sceneName);

        if (sceneName == "Disparo_Pompa" || sceneName == "Hinchar" || sceneName == "Laberinto" || sceneName == "Papel_Burbuja" || sceneName == "Escena_Final")
        {
            canvasPanel.gameObject.SetActive(true);
            timerImage.gameObject.SetActive(true);
            BubblesExplodedLocal.gameObject.SetActive(true);

            BubblesExplodedLocal.gameObject.GetComponent<TextMeshProUGUI>().text = "0";
        }

        // Esperar un frame para asegurarnos de que la escena se haya cargado
        yield return null;

        // Fase 2: Fundir de negro a transparente
        yield return StartCoroutine(Fade(1f, 0f));
    }

    /// <summary>
    /// Corrutina para interpolar el alpha de la imagen desde un valor inicial a uno final.
    /// </summary>
    /// <param name="startAlpha">Alpha inicial</param>
    /// <param name="endAlpha">Alpha final</param>
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

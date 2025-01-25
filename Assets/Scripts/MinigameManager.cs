using System.Collections;
using UnityEngine.UI; 
using Unity.VisualScripting;
using UnityEngine;
using TMPro; 

public class MinigameManager : MonoBehaviour
{
    GameManager gameManager;

    public float timeMaxLevel;
    float timeLeft; 
    
    int bubblesExplodedLocal;
    float fadeDuration = 1f;

    [HideInInspector]
    public Image fadeImage;
    Image timerImage; 

    [SerializeField]
    TextMeshProUGUI countdownText;
    TextMeshProUGUI bubblesExplodedLocalText; 
    
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
        
        fadeImage = GameObject.FindGameObjectWithTag("CountDownPanel").gameObject.GetComponent<Image>();
        timerImage = GameObject.FindGameObjectWithTag("TimerImage").gameObject.GetComponent<Image>();
        bubblesExplodedLocalText = GameObject.FindGameObjectWithTag("BubblesExplodedLocal").GetComponent<TextMeshProUGUI>();
        countdownText = GameObject.FindGameObjectWithTag("CountDownText").gameObject.GetComponent<TextMeshProUGUI>();

        countdownText.text = timeToStart.ToString();

        StartCoroutine(CountdownToStart());

        timeLeft = timeMaxLevel;
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


        countdownText.text = ""; 

        StartCoroutine(CuentaAtrasMinijuego()); 
    }

    public void ExplodeBubble()
    {
        bubblesExplodedLocal++;
        gameManager.BubblesKilled++;

        bubblesExplodedLocalText.text = bubblesExplodedLocal.ToString();
    }

    void LoadNextScene(string localNameNextScene)
    {
        transitionManager.FadeToScene(localNameNextScene);
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;

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

    IEnumerator CuentaAtrasMinijuego()
    {
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            //Llevarlo a potencia de 1
            timerImage.fillAmount = timeLeft/timeMaxLevel;

            yield return null;
        }

        if (timeLeft < 0)
        {
            LoadNextScene(nextSceneToLoad);
        }
    }
}

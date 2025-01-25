using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro; 

public class MinigameManager : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    public float timeMaxLevel;
    
    int bubblesExplodedLocal;

    //public TextMeshPro countdownText;
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

        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        yield return new WaitForSeconds(1f);
        timeToStart--;
        //countdownText.text = timeToStart.ToString(); 

        yield return new WaitForSeconds(1f);
        timeToStart--;
        //countdownText.text = timeToStart.ToString();

        yield return new WaitForSeconds(1f);
        timeToStart--;
        //Destroy(countdownText.gameObject); 
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
}

using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PressToContinue : MonoBehaviour
{
    SceneTransitionManager transitionManager;

    bool canSkip;

    public TextMeshProUGUI continueText;
    string firstContinueText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstContinueText = continueText.text;
        transitionManager = FindFirstObjectByType<SceneTransitionManager>();

        if (SceneManager.GetActiveScene().name == "Menu_Inicio_Escena_1")
        {
            continueText.text = "Tap to gather arround the fire...";
        }

        else
        {
            continueText.gameObject.SetActive(false);
            StartCoroutine(canSkipFunction());
        }

    }

    public void LoadNextScene(string localNameNextScene)
    {
        if (SceneManager.GetActiveScene().name == "Menu_Inicio_Escena_1")
        {
            StartCoroutine(MainMenuSpecial());
        }

        if (canSkip == true)
        {
            transitionManager.FadeToScene(localNameNextScene);
            continueText.gameObject.SetActive(false);
        }
    }

    IEnumerator canSkipFunction()
    {
        canSkip = false;
        yield return new WaitForSeconds(3f);

        continueText.gameObject.SetActive(true);
        canSkip = true;
    }

    IEnumerator MainMenuSpecial()
    {
        continueText.gameObject.SetActive(false);
        continueText.text = firstContinueText;

        yield return new WaitForSeconds(2f);

        StartCoroutine(canSkipFunction());
    }
}

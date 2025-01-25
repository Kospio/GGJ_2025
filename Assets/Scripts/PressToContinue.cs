using System.Collections;
using UnityEngine;

public class PressToContinue : MonoBehaviour
{
    SceneTransitionManager transitionManager;

    bool canSkip; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transitionManager = FindFirstObjectByType<SceneTransitionManager>();
    }

    void LoadNextScene(string localNameNextScene)
    {
        if(canSkip == true)
        {
            transitionManager.FadeToScene(localNameNextScene);
        }
    }

    IEnumerator canSkipFunction()
    {
        canSkip = false;
        yield return new WaitForSeconds(1f);
        canSkip = true;
    }
}

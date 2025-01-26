using UnityEngine;
using TMPro;

public class FinalController : MonoBehaviour
{
    GameManager gameManager;
    public TextMeshProUGUI finalText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        finalText.text = gameManager.BubblesKilled.ToString() + " bubbles";

        gameManager.BubblesKilled = 0; 
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int finalScore = 2;
    private int playerScore;
    private int aiScore;
    
    public bool gameStatus { get; set; }


    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text aiScoreScoreText;
    [SerializeField] private GameObject gameOverObject;
    [SerializeField] private Text wonMessageText;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        playerScore = 0;
        aiScore = 0;
        gameOverObject.SetActive(false);
        gameStatus = true;
        DisplayScore();
    }

    private void DisplayScore()
    {
        playerScoreText.text = playerScore.ToString();
        aiScoreScoreText.text = aiScore.ToString();
    }

    public void AddScore(string addScoreTo)
    {
        if (addScoreTo == "AI")
        {
            aiScore += 1;
            
            if (aiScore == finalScore)
                GameOver();
        }
        else if (addScoreTo == "Player")
        {
            playerScore += 1;

            if (playerScore == finalScore)
                GameOver();
        }

        DisplayScore();
    }

    private void GameOver()
    {
        gameOverObject.SetActive(true);
        if (aiScore == finalScore)
            wonMessageText.text = "AI WON";
        else if (playerScore == finalScore)
            wonMessageText.text = "YOU WON";
        gameStatus = false;
    }
}
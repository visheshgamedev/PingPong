using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int finalScore { get; private set; } = 5;
    public int playerScore { get; private set; }
    public int aiScore { get; private set; }

    public bool gameStatus { get; set; }

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

    public void NewGame()
    {
        playerScore = 0;
        aiScore = 0;
        gameStatus = true;
    }

    public void AddScore(string addScoreTo)
    {
        if (addScoreTo == "AI")
        {
            aiScore += 1;

            if (aiScore == finalScore)
            {
                gameStatus = false;
            }
        }
        else if (addScoreTo == "Player")
        {
            playerScore += 1;

            if (playerScore == finalScore)
            {
                gameStatus = false;
            }
        }
    }
}
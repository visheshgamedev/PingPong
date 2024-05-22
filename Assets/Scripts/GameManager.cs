using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int finalScore = 2;
    public int playerScore {
        get; set;
    }
    public int aiScore {
        get; set;
    }

    private BallMovement ballMovement;
    private Text playerScoreText;
    private Text aiScoreScoreText;
    
    [SerializeField] private GameObject gameOver;

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
            ballMovement = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallMovement>();
            playerScoreText = GameObject.FindGameObjectWithTag("PlayerScore").GetComponent<Text>();
            aiScoreScoreText = GameObject.FindGameObjectWithTag("AIScore").GetComponent<Text>();
        }
    }

    private void Start()
    {
        Invoke("NewGame", 2f);
    }

    public void NewGame()
    {
        playerScore = 0;
        aiScore = 0;
        gameOver.SetActive(false);
        ballMovement.InitialBallMovement();
    }

    public void ResetGame()
    {
        ballMovement.ResetBall();
        ballMovement.InitialBallMovement();

        playerScoreText.text = playerScore.ToString();
        aiScoreScoreText.text = aiScore.ToString();
    }

    private void GameOver()
    {
        gameOver.SetActive(true);
    }
}
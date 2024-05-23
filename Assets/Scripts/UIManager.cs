using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text aiScoreScoreText;
    [SerializeField] private GameObject gameOverObject;
    [SerializeField] private Text wonMessageText;

    private void Awake()
    {
        gameOverObject.SetActive(false);
    }

    private void Update()
    {
        DisplayScore();
        if (!GameManager.Instance.gameStatus)
        {
            GameOver();
        }
    }

    private void DisplayScore()
    {
        playerScoreText.text = GameManager.Instance.playerScore.ToString();
        aiScoreScoreText.text = GameManager.Instance.aiScore.ToString();
    }

    private void GameOver()
    {
        gameOverObject.SetActive(true);
        if (GameManager.Instance.aiScore == GameManager.Instance.finalScore)
            wonMessageText.text = "AI WON";
        else if (GameManager.Instance.playerScore == GameManager.Instance.finalScore)
            wonMessageText.text = "YOU WON";
        GameManager.Instance.gameStatus = false;
    }

}
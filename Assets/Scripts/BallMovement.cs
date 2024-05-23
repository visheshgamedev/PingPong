using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D ballRigidbody2D;
    private float ballMovementInitialSpeed = 5.0f;
    private float ballMovementMultiplier = 0.5f;
    private int ballHitCounter = 1;

    private void Awake()
    {
        ballRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke("InitialBallMovement", 2f);
    }

    private void FixedUpdate()
    {
        ballRigidbody2D.velocity = Vector2.ClampMagnitude(ballRigidbody2D.velocity, ballMovementInitialSpeed + (ballMovementMultiplier * ballHitCounter));
    }

    private void InitialBallMovement()
    {
        if (GameManager.Instance.gameStatus)
            ballRigidbody2D.velocity = Vector2.one * ballMovementInitialSpeed * ballMovementMultiplier;
    }

    private void ResetBall()
    {
        ballRigidbody2D.velocity = Vector2.zero;
        transform.position = Vector3.zero;
        ballHitCounter--;
        Invoke("InitialBallMovement", 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("AI"))
        {
            ballHitCounter++;
            PaddleBounce(collision.gameObject.transform);
        }
    }

    private void PaddleBounce(Transform paddleTransform)
    {
        Vector2 ballPosition = transform.position;
        Vector2 paddlePosition = paddleTransform.position;

        float xDirection, yDirection;

        if(transform.position.x > 0)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }

        yDirection = (ballPosition.y - paddlePosition.y) / paddleTransform.GetComponent<Collider2D>().bounds.size.y;
        if(yDirection == 0)
        {
            yDirection = 0.5f;
        }

        ballRigidbody2D.velocity = new Vector2(xDirection, yDirection) * ballMovementInitialSpeed * (ballMovementMultiplier * ballHitCounter);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerScore"))
            GameManager.Instance.AddScore("Player");
        else if (collision.gameObject.CompareTag("AIScore"))
            GameManager.Instance.AddScore("AI");

        ResetBall();
    }
}
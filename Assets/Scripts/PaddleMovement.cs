using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private Rigidbody2D paddleRigidbody2D;
    private Vector2 paddleMovementAxis = Vector2.zero;
    private float paddleMovementSpeed = 15.0f;
    private Transform ballTransform;

    [SerializeField] private bool isAI = false;

    private void Awake()
    {
        paddleRigidbody2D = GetComponent<Rigidbody2D>();
        ballTransform = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    private void Update()
    {
        if (isAI)
        {
            AIMovement();
            paddleMovementSpeed = 0.5f;
        }
        else
        {
            PlayerMovement();
        }
    }

    private void PlayerMovement()
    {
        paddleMovementAxis = new Vector2(0, Input.GetAxis("Vertical"));
    }

    private void AIMovement()
    {
        if (ballTransform.position.y > transform.position.y + 0.5f)
        {
            paddleMovementAxis = Vector2.up;
        }
        else if (ballTransform.position.y < transform.position.y - 0.5f)
        {
            paddleMovementAxis = Vector2.down;
        }
        else
        {
            paddleMovementAxis = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        paddleRigidbody2D.velocity = paddleMovementAxis * paddleMovementSpeed;
    }
}
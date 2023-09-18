using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballRigidbody;

    [SerializeField] float paddleMaxPosX = 7f;
    [SerializeField] float paddleposY = -3f;
    [SerializeField] float ballOffsetY = 0.5f;

    [SerializeField] float ballStartingSpeed = 10f;
    [SerializeField] float balldirectionspanX = 10f;

    bool ballReleased = false;


    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float paddlePosX = Mathf.Clamp(mousePos.x, -paddleMaxPosX, paddleMaxPosX);

        transform.position = new Vector2(paddlePosX, paddleposY);

        if (!ballReleased)
        {
            if (Input.GetMouseButton(0))
            {
                ballReleased = true;
                float ballStartingDirectionX = Random.Range(-balldirectionspanX, balldirectionspanX);
                ballRigidbody.velocity = new Vector2(ballStartingDirectionX, 1f).normalized * ballStartingSpeed;
            }

            ballRigidbody.position = new Vector2(paddlePosX, paddleposY + ballOffsetY);
        }
    }

    void ReleaseBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ballReleased = true;
            float BallStartingDirectionX = Random.Range(-balldirectionspanX, balldirectionspanX);
            ballRigidbody. velocity = new Vector2(BallStartingDirectionX, 1f).normalized * ballStartingSpeed;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Vector2 ballPosition = new Vector2(transform.position.x, transform.position.y + ballOffsetY);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(ballPosition, ballPosition + new Vector2(-balldirectionspanX, 1).normalized);
        Gizmos.DrawLine(ballPosition, ballPosition + new Vector2(balldirectionspanX, 1).normalized);
    }
}

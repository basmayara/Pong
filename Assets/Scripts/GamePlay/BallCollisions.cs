
using System;
using UnityEngine;

public class BallCollisions : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private BoardBounds board;
    [SerializeField] private Paddle playerPaddle;
    [SerializeField] private Paddle aiPaddle;
    [SerializeField] private float maxBounceAngle = 60f;

    public event Action OnPlayerPaddleHit;

    // LateUpdate: runs after Ball.Update has moved the ball this frame.
    private void LateUpdate()
    {
        if (GameManager.Instance.State != GameState.Playing) return;

        HandleWalls();
        HandleBackWall();

        if (HandlePaddle(playerPaddle, +1f))
            OnPlayerPaddleHit?.Invoke();

        HandlePaddle(aiPaddle, -1f);
    }

    private void HandleWalls()
    {
        float limit = board.HalfHeight - ball.Radius;
        Vector2 position = ball.Position;
        Vector2 direction = ball.Direction;

        if (position.y > limit && direction.y > 0f)
        {
            position.y = limit;
            direction.y = -direction.y;
        }
        else if (position.y < -limit && direction.y < 0f)
        {
            position.y = -limit;
            direction.y = -direction.y;
        }
        else
        {
            return;
        }

        ball.SetPosition(position);
        ball.SetDirection(direction);
    }

    // The AI side is a wall: the AI can never lose.
    private void HandleBackWall()
    {
        float rightLimit = board.HalfWidth - ball.Radius;
        Vector2 position = ball.Position;
        Vector2 direction = ball.Direction;

        if (position.x > rightLimit && direction.x > 0f)
        {
            position.x = rightLimit;
            direction.x = -direction.x;
            ball.SetPosition(position);
            ball.SetDirection(direction);
        }
    }

    // Returns true when the ball hit this paddle.
    private bool HandlePaddle(Paddle paddle, float xSign)
    {
        // Ignore the paddle if the ball is already moving away from it.
        if (ball.Direction.x * xSign >= 0f) return false;

        float dx = Mathf.Abs(ball.Position.x - paddle.X);
        float dy = Mathf.Abs(ball.Position.y - paddle.Y);

        bool hit = dx <= paddle.HalfWidth + ball.Radius &&
                   dy <= paddle.HalfHeight + ball.Radius;
        if (!hit) return false;

        ball.SetDirection(BallMath.PaddleBounce(
            ball.Position.y, paddle.Y, paddle.HalfHeight, xSign, maxBounceAngle));

        // Push the ball out of the paddle so it cannot hit twice.
        float pushedX = paddle.X + xSign * (paddle.HalfWidth + ball.Radius);
        ball.SetPosition(new Vector2(pushedX, ball.Position.y));

        return true;
    }
}
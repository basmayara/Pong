// GoalDetector.cs  (only detects the ball leaving on the player's side)
using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private BoardBounds board;

    private void LateUpdate()
    {
        if (GameManager.Instance.State != GameState.Playing) return;

        if (ball.Position.x < -(board.HalfWidth + ball.Radius))
            GameManager.Instance.PlayerMissed();
    }
}
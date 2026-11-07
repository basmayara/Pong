
using UnityEngine;

[RequireComponent(typeof(Paddle))]
public class AIController : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private float maxError = 1.2f;
    [SerializeField] private float refreshInterval = 0.3f;

    private Paddle paddle;
    private float error;
    private float timer;

    private void Awake() => paddle = GetComponent<Paddle>();

    private void Update()
    {
        if (GameManager.Instance.State != GameState.Playing) return;

        // The error is refreshed on a timer, not every frame,
        // otherwise the paddle would shake.
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            error = Random.Range(-maxError, maxError);
            timer = refreshInterval;
        }

        bool ballComingToMe = ball.Direction.x > 0f;
        float targetY = ballComingToMe ? ball.Position.y + error : 0f;

        paddle.MoveTowards(targetY);
    }
}
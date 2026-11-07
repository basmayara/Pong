// ServeController.cs
using System.Collections;
using UnityEngine;

public class ServeController : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private float serveDelay = 1f;
    [SerializeField] private float maxServeAngle = 35f;

    private Coroutine serveRoutine;

    private void OnEnable()
    {
        GameManager.Instance.OnGameStarted += HandleGameStarted;
        GameManager.Instance.OnGameOver += HandleGameOver;
    }

    private void OnDisable()
    {
        if (GameManager.Instance == null) return;

        GameManager.Instance.OnGameStarted -= HandleGameStarted;
        GameManager.Instance.OnGameOver -= HandleGameOver;
    }

    private void HandleGameStarted() => serveRoutine = StartCoroutine(Serve());

    private void HandleGameOver(int score, int rank)
    {
        if (serveRoutine != null)
        {
            StopCoroutine(serveRoutine);
            serveRoutine = null;
        }

        ball.Stop();
    }

    private IEnumerator Serve()
    {
        ball.ResetToCenter();
        yield return new WaitForSeconds(serveDelay);

        if (GameManager.Instance.State != GameState.Playing) yield break;

        ball.Launch(BallMath.RandomServeDirection(maxServeAngle));
        serveRoutine = null;
    }
}
using System;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState State { get; private set; }
    public int Score { get; private set; }

    public event Action OnGameStarted;
    public event Action<int> OnScoreChanged;
    public event Action<int> OnGameOver;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    private void Start()
    {
        Score = 0;
        State = GameState.Playing;

        OnScoreChanged?.Invoke(Score);
        OnGameStarted?.Invoke();
    }

    public void PlayerScored()
    {
        if (State != GameState.Playing) return;

        Score++;
        OnScoreChanged?.Invoke(Score);
    }

    public void PlayerMissed()
    {
        if (State != GameState.Playing) return;

        State = GameState.GameOver;
        OnGameOver?.Invoke(Score);
    }
}
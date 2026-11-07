
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text finalScoreLabel;
    [SerializeField] private LeaderboardView leaderboardView;

    private void Awake() => panel.SetActive(false);

    private void OnEnable() => GameManager.Instance.OnGameOver += Show;

    private void OnDisable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnGameOver -= Show;
    }

    private void Show(int score, int rank)
    {
        panel.SetActive(true);
        finalScoreLabel.text = $"Score: {score}";
        leaderboardView.Show(GameManager.Instance.Leaderboard.Scores, rank);
    }

    // Hooked to the Retry and Menu buttons.
    public void OnRetryClicked() => SceneLoader.LoadGame();
    public void OnMenuClicked() => SceneLoader.LoadMenu();
}
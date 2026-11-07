// ScoreUI.cs
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreLabel;

    private void OnEnable()
    {
        GameManager.Instance.OnScoreChanged += UpdateScore;
        UpdateScore(GameManager.Instance.Score);
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnScoreChanged -= UpdateScore;
    }

    private void UpdateScore(int score) => scoreLabel.text = score.ToString();
}
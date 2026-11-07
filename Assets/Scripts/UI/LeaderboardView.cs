
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private TMP_Text[] rows; // 10 texts
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color highlightColor = Color.yellow;

    public void Show(IReadOnlyList<int> scores, int highlightRank)
    {
        for (int i = 0; i < rows.Length; i++)
        {
            bool hasScore = i < scores.Count;

            rows[i].text = hasScore ? $"{i + 1}.  {scores[i]}" : $"{i + 1}.  ---";
            rows[i].color = i == highlightRank ? highlightColor : normalColor;
        }
    }
}
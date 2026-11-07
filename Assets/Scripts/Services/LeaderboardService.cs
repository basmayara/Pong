using System;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardService
{
    public const int MaxEntries = 10;
    private const string PrefsKey = "leaderboard";

    [Serializable]
    private class LeaderboardData
    {
        public List<int> scores = new List<int>();
    }

    private readonly List<int> scores = new List<int>();
    public IReadOnlyList<int> Scores => scores;

    public void Initialize()
    {
        scores.Clear();

        string json = PlayerPrefs.GetString(PrefsKey, "");
        if (string.IsNullOrEmpty(json)) return;

        LeaderboardData data = JsonUtility.FromJson<LeaderboardData>(json);
        if (data?.scores == null) return;

        scores.AddRange(data.scores);
        SortAndLimit();
    }

    //  (0 = first place) or -1 if not in the top 10.
    public int Submit(int score)
    {
        // A score of 0 is not worth a place on the board.
        if (score <= 0) return -1;

        scores.Add(score);
        SortAndLimit();
        Save();

        // IndexOf returns -1 by itself if the score was cut off.
        return scores.IndexOf(score);
    }

    private void SortAndLimit()
    {
        scores.Sort((a, b) => b.CompareTo(a));

        if (scores.Count > MaxEntries)
            scores.RemoveRange(MaxEntries, scores.Count - MaxEntries);
    }

    private void Save()
    {
        LeaderboardData data = new LeaderboardData { scores = new List<int>(scores) };

        PlayerPrefs.SetString(PrefsKey, JsonUtility.ToJson(data));
        PlayerPrefs.Save();
    }
}
// RallyScorer.cs  
using UnityEngine;

public class RallyScorer : MonoBehaviour
{
    [SerializeField] private BallCollisions collisions;

    private void OnEnable() => collisions.OnPlayerPaddleHit += HandleHit;
    private void OnDisable() => collisions.OnPlayerPaddleHit -= HandleHit;

    private void HandleHit() => GameManager.Instance.PlayerScored();
}
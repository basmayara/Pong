
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private BoardBounds board;
    [SerializeField] private float speed = 10f;

    // Assumes a 1x1 sprite scaled to the paddle size.
    public float HalfWidth => transform.localScale.x / 2f;
    public float HalfHeight => transform.localScale.y / 2f;
    public float X => transform.position.x;
    public float Y => transform.position.y;

    private void Awake()
    {
       
        if (board == null)
            Debug.LogError($"{name}: Paddle has no BoardBounds assigned.", this);
    }

    public void MoveTowards(float targetY)
    {
        if (board == null) return;

        float limit = board.HalfHeight - HalfHeight;
        targetY = Mathf.Clamp(targetY, -limit, limit);

        Vector3 position = transform.position;
        position.y = Mathf.MoveTowards(position.y, targetY, speed * Time.deltaTime);
        transform.position = position;
    }
}
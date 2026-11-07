using UnityEngine; 

// Ball has ONE job move itself. It knows nothing about walls, paddles or score.

public class Ball : MonoBehaviour 
{
    
    [SerializeField] private float speed = 8f;

    // true ->the ball is moving false ->the ball is waiting 
   
    private bool isMoving;

    // The (x, y) with length 1.  can READ it, only Ball can CHANGE it.
    
    public Vector2 Direction { get; private set; }
    public Vector2 Position => transform.position;

   
    public float Radius => transform.localScale.x / 2f;

    
    
    private void Update()
    {
        // If the ball -> stop do ntg .
       
        if (!isMoving) return;

        // new pos = old pos + direction * speed * time .
      
        transform.position += (Vector3)(Direction * speed * Time.deltaTime);
    }

  
    public void Launch(Vector2 direction)
    {
        Direction = direction.normalized;

       
        isMoving = true;
    }

    // Stops the ball (used at game over).
  
    public void Stop() => isMoving = false;

    public void SetDirection(Vector2 direction) => Direction = direction.normalized;

  
    public void SetPosition(Vector2 position) => transform.position = position;

    public void ResetToCenter()
    {
        isMoving = false;                // stop moving 
        Direction = Vector2.zero;        // no direction yet 
        transform.position = Vector3.zero; // (0, 0, 0) = center 
    }
}
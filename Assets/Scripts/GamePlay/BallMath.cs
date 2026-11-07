using UnityEngine; 

public static class BallMath
{
   
    public static Vector2 RandomServeDirection(float maxAngleDeg)
    {
      
        float angle = Random.Range(-maxAngleDeg, maxAngleDeg) * Mathf.Deg2Rad;

        
        float side = Random.value < 0.5f ? -1f : 1f;

        // Turn the angle into a direction (x, y):
        //   cos(angle) = horizontal part* by side to flip left or right
        //   sin(angle) = vertical part (up or down)
        // The length is always 1 because cos^2+ sin^2 = 1,
        // so the speed is controlled only by Ball.speed.
        //  angle = 20°, side = +1 -> (0.94, 0.34)
        return new Vector2(side * Mathf.Cos(angle), Mathf.Sin(angle));
    }

  
    public static Vector2 PaddleBounce(
        float ballY,
        float paddleY,
        float paddleHalfHeight,
        float xSign,
        float maxBounceAngleDeg)
    {
      
        //   +1 = top edge, 0 = center, -1 = bottom .
        // (ballY - paddleY) distance from center
        // Ex: ballY = 2.8, paddleY = 2, halfHeight = 1 -> offset = 0.8
        float offset = Mathf.Clamp((ballY - paddleY) / paddleHalfHeight, -1f, 1f);

        
        // C hit (0) -> 0°, edge hit (1) -> 60°.
       
        float angle = offset * maxBounceAngleDeg * Mathf.Deg2Rad;


        // xSign decides left or right, sin(angle) decides up or down.
        // Example: xSign = +1, angle = 48° -> (0.67, 0.74)
        
        return new Vector2(xSign * Mathf.Cos(angle), Mathf.Sin(angle));
    }
}
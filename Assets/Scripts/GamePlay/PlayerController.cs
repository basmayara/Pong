
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Paddle))]
public class PlayerController : MonoBehaviour
{
    private Paddle paddle;
    private Camera mainCamera;

    private void Awake()
    {
        paddle = GetComponent<Paddle>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (GameManager.Instance.State != GameState.Playing) return;

        paddle.MoveTowards(ReadPointerWorldY());
    }

    private float ReadPointerWorldY()
    {
        Vector2 screenPosition;

        if (Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.isPressed)
        {
            screenPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        }
        else if (Mouse.current != null)
        {
            screenPosition = Mouse.current.position.ReadValue();
        }
        else
        {
            return paddle.Y; //  stay in place
        }

        // z is the distance from the camera, needed by ScreenToWorldPoint.
        Vector3 world = mainCamera.ScreenToWorldPoint(new Vector3(
            screenPosition.x,
            screenPosition.y,
            -mainCamera.transform.position.z));

        return world.y;
    }
}
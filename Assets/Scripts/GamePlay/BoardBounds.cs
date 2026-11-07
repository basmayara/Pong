
using UnityEngine;

public class BoardBounds : MonoBehaviour
{
    public float HalfWidth { get; private set; }
    public float HalfHeight { get; private set; }

    private void Awake()
    {
        Camera cam = Camera.main;

        if (cam == null || !cam.orthographic)
        {
            Debug.LogError("BoardBounds requires an orthographic Main Camera.");
            enabled = false;
            return;
        }

        HalfHeight = cam.orthographicSize;
        HalfWidth = HalfHeight * cam.aspect;
    }
}
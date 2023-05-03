using UnityEngine;

public class Fullscreen : MonoBehaviour
{
    public Camera gameCamera;

    private void Start()
    {
        if (gameCamera == null)
        {
            gameCamera = Camera.main;
        }

        // Set the aspect ratio of the game view
        float targetAspectRatio = 4.0f / 3.0f;
        float currentAspectRatio = (float)Screen.width / Screen.height;
        float scaleHeight = currentAspectRatio / targetAspectRatio;

        if (scaleHeight < 1.0f)
        {
            gameCamera.rect = new Rect(0, (1.0f - scaleHeight) / 2.0f, 1.0f, scaleHeight);
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            gameCamera.rect = new Rect((1.0f - scaleWidth) / 2.0f, 0, scaleWidth, 1.0f);
        }

        // Enter fullscreen mode
        Screen.fullScreen = true;
        Screen.SetResolution(1024, 768, FullScreenMode.FullScreenWindow);
    }
}

using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadGame()
    {
        SceneManager.LoadScene("Pong");
    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene("PongMainMenu");
    }
}
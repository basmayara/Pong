using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private const string MainMenuScene = "PongMainMenu";
    private const string GameScene = "Pong";

    public static void LoadMenu() => SceneManager.LoadScene(MainMenuScene);
    public static void LoadGame() => SceneManager.LoadScene(GameScene);
}

using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private const string MainMenuScene = "MainMenu";
    private const string GameScene = "Game";

    public static void LoadMenu() => SceneManager.LoadScene(MainMenuScene);
    public static void LoadGame() => SceneManager.LoadScene(GameScene);
}
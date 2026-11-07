using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void OnPlayClicked()
    {
        SceneLoader.LoadGame();
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
    public void Gamescene()
    {
        SceneManager.LoadScene("Scenes/TestingEnemies");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

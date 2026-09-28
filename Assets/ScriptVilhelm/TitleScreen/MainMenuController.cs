using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
    public void Gamescene()
    {
        SceneManager.LoadScene("Scenes/Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

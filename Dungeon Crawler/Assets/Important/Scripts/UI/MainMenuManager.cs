using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName); // Makes it so that I can chooses a scene to go to.
        Cursor.visible = false; // Sets my cursor visiblity to false
        Cursor.lockState = CursorLockMode.Locked; // This locks my cursor
        Time.timeScale = 1f; // Pauses the time in the game
    }

    public void QuitGame()
    {
        Application.Quit(); // Quits the game
    } 
}
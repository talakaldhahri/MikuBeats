using UnityEngine;
using UnityEngine.SceneManagement; // Required to switch scenes

public class MainMenu : MonoBehaviour
{
    // call this function to load the game
    public void PlayGame()
    {
        // IMPORTANT: Make sure "GameScene" matches the exact name of your gameplay scene!
        SceneManager.LoadScene("Start"); 
    }

    // Call this function to close the game
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}

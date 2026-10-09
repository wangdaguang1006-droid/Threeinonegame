
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    // Mad Driver
    public void PlayMadDriver()
    {
        SceneManager.LoadScene("Prototype 1");
    }

    // Fly Like a Bird
    public void PlayFlyGame()
    {
        SceneManager.LoadScene("Challenge 1");
    }

    // I'm a Sumo and a Ball
    public void PlaySumoGame()
    {
        SceneManager.LoadScene("Prototype 4");
    }

    // Exit Game
    public void ExitGame()
    {
        Debug.Log("Exiting Game...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

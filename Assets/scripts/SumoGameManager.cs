
using UnityEngine;
using UnityEngine.SceneManagement;

public class SumoGameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies;

    public GameObject winPanel;
    public GameObject losePanel;

    public float fallHeight = -5f;

    private bool gameEnded = false;

    void Start()
    {
        Time.timeScale = 1f;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    void Update()
    {
        if (gameEnded) return;

        // Check if player fell off
        if (player.transform.position.y < fallHeight)
        {
            gameEnded = true;
            losePanel.SetActive(true);
            Time.timeScale = 0f;
            return;
        }

        // Check if all enemies fell off
        bool allEnemiesFell = true;

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null &&
                enemy.transform.position.y >= fallHeight)
            {
                allEnemiesFell = false;
                break;
            }
        }

        if (allEnemiesFell && enemies.Length > 0)
        {
            gameEnded = true;
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainmenu");
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; // Painel de pause no HUD

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;          
            pausePanel.SetActive(true);  
        }
        else
        {
            Time.timeScale = 1;          
            pausePanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("MainMenu"); 
    }


    public void RestartGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

}

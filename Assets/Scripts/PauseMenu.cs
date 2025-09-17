using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        ShowCursor(true); // cursor visível
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        ShowCursor(false); // cursor escondido
    }

    private void ShowCursor(bool show)
    {
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }

    // 🔹 Reinicia a cena atual
    public void RestartLevel()
    {
        Time.timeScale = 1f; // garante que o tempo volte ao normal
        isPaused = false;
        ShowCursor(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 🔹 Volta para o menu principal
    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; // garante que o tempo volte ao normal
        isPaused = false;
        ShowCursor(true);

        SceneManager.LoadScene("MainMenu"); // substitua pelo nome exato da sua cena
    }
}

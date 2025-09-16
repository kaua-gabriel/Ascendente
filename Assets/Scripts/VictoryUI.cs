using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryUI : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1f; // garante que o jogo volte ao normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f; // garante que o jogo volte ao normal
        SceneManager.LoadScene("MainMenu"); // troque pelo nome da sua cena de menu
    }
}

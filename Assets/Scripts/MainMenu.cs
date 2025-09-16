using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject characterSelectPanel; // arraste o painel no Inspector

    public void StartGame()
    {
        // Ativa o painel de seleção de personagem
        characterSelectPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Sair do jogo!");
        Application.Quit();
    }
}

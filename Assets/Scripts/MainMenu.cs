using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject characterSelectPanel; // arraste o painel no Inspector

    private void Start()
    {
        // No menu inicial o cursor precisa estar visível
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

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

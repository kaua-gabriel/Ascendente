using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionUI : MonoBehaviour
{
    [Header("Botões de Seleção")]
    public Button meninaButton;
    public Button meninoButton;

    [Header("Auras/Outlines")]
    public Outline meninaOutline;
    public Outline meninoOutline;

    [Header("Cena do jogo")]
    public string gameSceneName = "GameScene";

    private string chosenCharacter = "";

    void Awake()
    {
        // Garantir que não haja nulls
        if (meninaButton == null || meninoButton == null ||
            meninaOutline == null || meninoOutline == null)
        {
            Debug.LogError("Por favor, arraste todos os botões e outlines no Inspector!");
            return;
        }

        // Desativa auras inicialmente
        meninaOutline.enabled = false;
        meninoOutline.enabled = false;

        // Configura listeners dos botões de seleção
        meninaButton.onClick.AddListener(() => SelectCharacter("Menina"));
        meninoButton.onClick.AddListener(() => SelectCharacter("Menino"));
    }

    void SelectCharacter(string character)
    {
        chosenCharacter = character;

        // Salva a escolha
        PlayerPrefs.SetString("playerSelected", chosenCharacter);
        PlayerPrefs.Save();

        // Atualiza a aura visual
        if (character == "Menina")
        {
            meninaOutline.enabled = true;
            meninoOutline.enabled = false;
        }
        else
        {
            meninaOutline.enabled = false;
            meninoOutline.enabled = true;
        }

        Debug.Log("Personagem escolhido: " + chosenCharacter);
    }

    // Deve ser ligado ao botão Confirmar
    public void ConfirmSelection()
    {
        if (string.IsNullOrEmpty(chosenCharacter))
        {
            Debug.LogWarning("Escolha um personagem antes de confirmar!");
            return;
        }

        // Carrega a cena do jogo
        SceneManager.LoadScene(gameSceneName);
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionUI : MonoBehaviour
{
    [Header("Botões de Seleção")]
    public Button meninaButton;
    public Button meninoButton;

    [Header("Auras / Imagens de seleção")]
    public Image meninaOutline; // pode ser Image ou Outline
    public Image meninoOutline;

    [Header("Cena do jogo")]
    public string gameSceneName = "GameScene";

    private string chosenCharacter = "";

    void Awake()
    {
        // Verifica se os campos foram preenchidos
        if (meninaButton == null || meninoButton == null ||
            meninaOutline == null || meninoOutline == null)
        {
            Debug.LogError("Por favor, arraste todos os botões e outlines/imagens no Inspector!");
            return;
        }

        // Desativa as auras inicialmente
        meninaOutline.enabled = false;
        meninoOutline.enabled = false;

        // Configura os listeners dos botões
        meninaButton.onClick.AddListener(() => SelectCharacter("Menina"));
        meninoButton.onClick.AddListener(() => SelectCharacter("Menino"));
    }

    void SelectCharacter(string character)
    {
        chosenCharacter = character;

        // Salva a escolha
        PlayerPrefs.SetString("playerSelected", chosenCharacter);
        PlayerPrefs.Save();

        // Atualiza a aura visual usando Image
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

using UnityEngine;

public class FinalNPCSelector : MonoBehaviour
{
    public GameObject meninaNPC;
    public GameObject meninoNPC;

    void Start()
    {
        string chosenPlayer = PlayerPrefs.GetString("playerSelected", "Ninguém");
        Debug.Log("Player selecionado: " + chosenPlayer);

        // Desativa ambos inicialmente
        meninaNPC.SetActive(false);
        meninoNPC.SetActive(false);

        // Ativa apenas o NPC correspondente
        if (chosenPlayer == "Menina")
        {
            // Jogador é Menina, NPC final é Menino
            meninoNPC.SetActive(true);
        }
        else if (chosenPlayer == "Menino")
        {
            // Jogador é Menino, NPC final é Menina
            meninaNPC.SetActive(true);
        }
        else
        {
            Debug.LogError("Nenhum player válido selecionado!");
        }
    }
}

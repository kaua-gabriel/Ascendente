using UnityEngine;

public class FinalNPCSelector : MonoBehaviour
{
    public GameObject meninaNPC;
    public GameObject meninoNPC;

    void Start()
    {
        string chosenPlayer = PlayerPrefs.GetString("playerSelected", "Ningu�m");
        Debug.Log("Player selecionado: " + chosenPlayer);

        // Desativa ambos inicialmente
        meninaNPC.SetActive(false);
        meninoNPC.SetActive(false);

        // Ativa apenas o NPC correspondente
        if (chosenPlayer == "Menina")
        {
            // Jogador � Menina, NPC final � Menino
            meninoNPC.SetActive(true);
        }
        else if (chosenPlayer == "Menino")
        {
            // Jogador � Menino, NPC final � Menina
            meninaNPC.SetActive(true);
        }
        else
        {
            Debug.LogError("Nenhum player v�lido selecionado!");
        }
    }
}

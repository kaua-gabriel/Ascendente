using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public GameObject meninaPlayer;
    public GameObject meninoPlayer;

    void Start()
    {
        string chosen = PlayerPrefs.GetString("playerSelected", "Ningu�m");
        Debug.Log("Player selecionado: " + chosen);

        if (chosen == "Menina")
        {
            meninaPlayer.SetActive(true);
            meninoPlayer.SetActive(false);
        }
        else if (chosen == "Menino")
        {
            meninoPlayer.SetActive(true);
            meninaPlayer.SetActive(false);
        }
        else
        {
            Debug.LogError("Nenhum player v�lido selecionado!");
        }
    }
}

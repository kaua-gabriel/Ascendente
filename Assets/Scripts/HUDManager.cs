using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Image[] cristais; // Arraste as 4 imagens aqui no Inspector

    // Função para ativar o cristal no HUD
    public void AtivarCristal(int index)
    {
        if (index >= 0 && index < cristais.Length)
        {
            cristais[index].gameObject.SetActive(true);
        }
    }
}

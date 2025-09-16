using UnityEngine;
using UnityEngine.UI;

public class PauseButtonIcon : MonoBehaviour
{
    public MusicPlaylist musicPlaylist; // Script que controla a música
    public Image buttonImage;           // Image do botão
    public Sprite playIcon;             // Ícone de "play"
    public Sprite pauseIcon;            // Ícone de "pause"

    void Update()
    {
        // Se a música estiver tocando, mostra o ícone de pause
        if (musicPlaylist.audioSource.isPlaying)
        {
            buttonImage.sprite = pauseIcon;
        }
        // Se a música estiver pausada, mostra o ícone de play
        else
        {
            buttonImage.sprite = playIcon;
        }
    }
}

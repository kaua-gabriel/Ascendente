using UnityEngine;
using UnityEngine.UI;

public class PauseButtonIcon : MonoBehaviour
{
    public MusicPlaylist musicPlaylist; // Script que controla a m�sica
    public Image buttonImage;           // Image do bot�o
    public Sprite playIcon;             // �cone de "play"
    public Sprite pauseIcon;            // �cone de "pause"

    void Update()
    {
        // Se a m�sica estiver tocando, mostra o �cone de pause
        if (musicPlaylist.audioSource.isPlaying)
        {
            buttonImage.sprite = pauseIcon;
        }
        // Se a m�sica estiver pausada, mostra o �cone de play
        else
        {
            buttonImage.sprite = playIcon;
        }
    }
}

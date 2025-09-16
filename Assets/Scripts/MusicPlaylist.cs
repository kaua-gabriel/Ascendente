using UnityEngine;

public class MusicPlaylist : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] playlist;
    private int index = 0;

    void Start()
    {
        if (playlist.Length > 0)
        {
            audioSource.clip = playlist[index];
            audioSource.Play();
        }
    }

    public void PauseMusic()
    {
        if (audioSource.isPlaying) audioSource.Pause();
        else audioSource.Play();
    }

    public void NextMusic()
    {
        if (playlist.Length == 0) return;
        index = (index + 1) % playlist.Length;
        audioSource.clip = playlist[index];
        audioSource.Play();
    }

    public void PreviousMusic()
    {
        if (playlist.Length == 0) return;
        index = (index - 1 + playlist.Length) % playlist.Length;
        audioSource.clip = playlist[index];
        audioSource.Play();
    }
}

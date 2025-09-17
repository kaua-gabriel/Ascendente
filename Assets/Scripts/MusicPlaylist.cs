using UnityEngine;

public class MusicPlaylist : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] playlist;
    private int index = 0;
    private bool isPaused = false; // nova flag

    void Start()
    {
        if (playlist.Length > 0)
        {
            index = Random.Range(0, playlist.Length);
            audioSource.clip = playlist[index];
            audioSource.Play();
        }
    }

    void Update()
    {
        // Toca outra música só se não estiver pausada
        if (!audioSource.isPlaying && playlist.Length > 0 && !isPaused)
        {
            PlayRandomMusic();
        }
    }

    public void PauseMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            isPaused = true;
        }
        else
        {
            audioSource.Play();
            isPaused = false;
        }
    }

    public void NextMusic()
    {
        if (playlist.Length == 0) return;
        index = (index + 1) % playlist.Length;
        audioSource.clip = playlist[index];
        audioSource.Play();
        isPaused = false;
    }

    public void PreviousMusic()
    {
        if (playlist.Length == 0) return;
        index = (index - 1 + playlist.Length) % playlist.Length;
        audioSource.clip = playlist[index];
        audioSource.Play();
        isPaused = false;
    }

    private void PlayRandomMusic()
    {
        if (playlist.Length == 0) return;

        int newIndex;
        do
        {
            newIndex = Random.Range(0, playlist.Length);
        } while (newIndex == index && playlist.Length > 1);

        index = newIndex;
        audioSource.clip = playlist[index];
        audioSource.Play();
    }
}

using UnityEngine;
using UnityEngine.UI; // Se for usar UI Image, senão para SpriteRenderer, pode ignorar

public class FrameByFrame : MonoBehaviour
{
    // Se for um sprite no SpriteRenderer
    public SpriteRenderer spriteRenderer;

    // Ou se for UI Image
    public Image image;

    // Lista de frames (sprites) que você quer mostrar
    public Sprite[] frames;

    // Índice atual do frame
    private int currentFrame = 0;

    // Tempo entre cada frame (opcional, se quiser automático)
    public float frameTime = 0.2f;
    private float timer = 0f;
    public bool playAutomatically = false;

    void Update()
    {
        if (playAutomatically && frames.Length > 0)
        {
            timer += Time.deltaTime;
            if (timer >= frameTime)
            {
                timer = 0f;
                NextFrame();
            }
        }
    }

    // Mostra o próximo frame da lista
    public void NextFrame()
    {
        if (frames.Length == 0) return;

        currentFrame++;
        if (currentFrame >= frames.Length)
            currentFrame = 0;

        ApplyFrame();
    }

    // Mostra o frame anterior
    public void PreviousFrame()
    {
        if (frames.Length == 0) return;

        currentFrame--;
        if (currentFrame < 0)
            currentFrame = frames.Length - 1;

        ApplyFrame();
    }

    // Mostra um frame específico pelo índice
    public void ShowFrame(int index)
    {
        if (frames.Length == 0) return;
        if (index < 0 || index >= frames.Length) return;

        currentFrame = index;
        ApplyFrame();
    }

    // Aplica o sprite no SpriteRenderer ou na UI Image
    private void ApplyFrame()
    {
        if (spriteRenderer != null)
            spriteRenderer.sprite = frames[currentFrame];
        if (image != null)
            image.sprite = frames[currentFrame];
    }
}

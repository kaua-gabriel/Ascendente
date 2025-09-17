using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class StarsBlink : MonoBehaviour
{
    [Header("Imagens das estrelas")]
    public List<Image> stars;         // arraste suas imagens aqui

    [Header("Configura��es")]
    public float fallSpeedMin = 50f;  // velocidade m�nima da queda (pixels/s)
    public float fallSpeedMax = 150f; // velocidade m�xima da queda
    public float startY = 600f;       // altura inicial (em pixels)
    public float endY = -100f;        // altura de rein�cio (em pixels)
    public float startXMin = 0f;      // posi��o X m�nima
    public float startXMax = 800f;    // posi��o X m�xima (ajuste ao tamanho do Canvas)

    [Header("Piscar")]
    public float minAlpha = 0.3f;        // transpar�ncia m�nima
    public float maxAlpha = 1f;          // transpar�ncia m�xima
    public float blinkSpeedMin = 1f;     // velocidade m�nima de piscar
    public float blinkSpeedMax = 3f;     // velocidade m�xima de piscar

    private Dictionary<Image, float> speeds = new Dictionary<Image, float>();
    private Dictionary<Image, float> blinkSpeeds = new Dictionary<Image, float>();
    private Dictionary<Image, float> blinkOffsets = new Dictionary<Image, float>();

    void Start()
    {
        foreach (var star in stars)
        {
            if (star == null) continue;

            // Posi��o inicial aleat�ria no Canvas
            float randomX = Random.Range(startXMin, startXMax);
            float randomY = Random.Range(startY, startY + 100f);
            star.rectTransform.anchoredPosition = new Vector2(randomX, randomY);

            // Velocidade de queda aleat�ria
            speeds[star] = Random.Range(fallSpeedMin, fallSpeedMax);

            // Velocidade e offset de piscar
            blinkSpeeds[star] = Random.Range(blinkSpeedMin, blinkSpeedMax);
            blinkOffsets[star] = Random.Range(0f, Mathf.PI * 2f);
        }
    }

    void Update()
    {
        foreach (var star in stars)
        {
            if (star == null) continue;

            // Queda
            Vector2 pos = star.rectTransform.anchoredPosition;
            pos.y -= speeds[star] * Time.deltaTime;

            if (pos.y < endY)
            {
                pos.y = startY + Random.Range(0f, 100f);
                pos.x = Random.Range(startXMin, startXMax);
            }
            star.rectTransform.anchoredPosition = pos;

            // Piscar
            float alpha = Mathf.Lerp(minAlpha, maxAlpha, (Mathf.Sin(Time.time * blinkSpeeds[star] + blinkOffsets[star]) + 1f) / 2f);
            Color c = star.color;
            c.a = alpha;
            star.color = c;
        }
    }
}

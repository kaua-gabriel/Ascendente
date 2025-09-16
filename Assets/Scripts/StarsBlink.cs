using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StarsBlink : MonoBehaviour
{
    [Header("Imagens das estrelas")]
    public List<Image> stars;         // arraste suas 9 imagens aqui

    [Header("Configura��es")]
    public float fallSpeedMin = 50f;  // velocidade m�nima da queda (pixels/s)
    public float fallSpeedMax = 150f; // velocidade m�xima da queda
    public float startY = 600f;       // altura inicial (em pixels)
    public float endY = -100f;        // altura de rein�cio (em pixels)
    public float startXMin = 0f;      // posi��o X m�nima
    public float startXMax = 800f;    // posi��o X m�xima (ajuste ao tamanho do Canvas)

    private Dictionary<Image, float> speeds = new Dictionary<Image, float>();
    private Dictionary<Image, Vector3> originalPositions = new Dictionary<Image, Vector3>();

    private void Start()
    {
        foreach (var star in stars)
        {
            if (star != null)
            {
                // inicializa posi��es aleat�rias no topo
                float randomX = Random.Range(startXMin, startXMax);
                star.rectTransform.localPosition = new Vector3(randomX, Random.Range(startY, startY + 100f), 0);
                originalPositions[star] = star.rectTransform.localPosition;

                // velocidade aleat�ria para cada estrela
                speeds[star] = Random.Range(fallSpeedMin, fallSpeedMax);
            }
        }
    }

    private void Update()
    {
        foreach (var star in stars)
        {
            if (star == null) continue;

            Vector3 pos = star.rectTransform.localPosition;
            pos.y -= speeds[star] * Time.deltaTime;

            // se passou do fim, reseta no topo
            if (pos.y < endY)
            {
                pos.y = startY + Random.Range(0f, 100f);
                pos.x = Random.Range(startXMin, startXMax);
            }

            star.rectTransform.localPosition = pos;
        }
    }
}

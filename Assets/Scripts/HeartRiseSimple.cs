using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartRiseSimple : MonoBehaviour
{
    [Header("Corações na cena (desativados)")]
    public List<GameObject> hearts;      // arraste os 4 corações que já estão na cena
    public float riseSpeed = 1f;         // unidades por segundo
    public float duration = 1.5f;        // tempo que sobe
    public float popScale = 1.5f;        // quanto cresce no "pop"
    public float popTime = 0.2f;         // duração do pop
    public float spawnInterval = 0.3f;   // intervalo entre cada coração

    [Header("Tela de Vitória")]
    public GameObject victoryScreen;     // painel de vitória (UI)

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;
        if (other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(ActivateHearts());
        }
    }

    private IEnumerator ActivateHearts()
    {
        // Cria uma cópia da lista para embaralhar
        List<GameObject> heartPool = new List<GameObject>(hearts);

        while (heartPool.Count > 0)
        {
            int index = Random.Range(0, heartPool.Count);
            GameObject heart = heartPool[index];
            heartPool.RemoveAt(index);

            heart.SetActive(true);
            StartCoroutine(RiseAndPopHeart(heart));

            yield return new WaitForSeconds(spawnInterval);
        }

        // Espera todos os corações subirem antes de mostrar vitória
        yield return new WaitForSeconds(duration + popTime);
        if (victoryScreen != null)
        {
            victoryScreen.SetActive(true);
            Time.timeScale = 0f; // pausa o jogo
        }
    }

    private IEnumerator RiseAndPopHeart(GameObject heart)
    {
        // Pop inicial
        Vector3 originalScale = heart.transform.localScale;
        Vector3 targetScale = originalScale * popScale;
        float timer = 0f;

        while (timer < popTime)
        {
            heart.transform.localScale = Vector3.Lerp(originalScale, targetScale, timer / popTime);
            timer += Time.deltaTime;
            yield return null;
        }
        heart.transform.localScale = originalScale;

        // Subida suave
        timer = 0f;
        Vector3 startPos = heart.transform.position;

        while (timer < duration)
        {
            heart.transform.position = startPos + Vector3.up * riseSpeed * (timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        heart.SetActive(false); // desativa novamente
    }
}

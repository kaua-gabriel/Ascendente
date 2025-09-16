using UnityEngine;
using TMPro;
using System.Collections;

public class OneWayCeiling : MonoBehaviour
{
    private Collider2D col;
    private bool hasBeenTriggered = false;

    [Header("Nome da Fase")]
    [TextArea]
    public string phaseName;          // Nome da fase
    public float displayTime = 3f;    // Quanto tempo fica na tela

    public GameObject phaseTextObject; // Objeto do Canvas que já existe (desativado)
    private TextMeshProUGUI phaseText;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        if (col == null)
            Debug.LogError("Collider2D não encontrado em " + gameObject.name);
        else
            col.isTrigger = true; // começa como trigger

        if (phaseTextObject != null)
            phaseText = phaseTextObject.GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!hasBeenTriggered && other.CompareTag("Player"))
        {
            if (other.transform.position.y > transform.position.y)
            {
                hasBeenTriggered = true;
                col.isTrigger = false; // plataforma fica sólida

                if (phaseTextObject != null)
                    StartCoroutine(ShowPhaseName());
            }
        }
    }

    private IEnumerator ShowPhaseName()
    {
        phaseTextObject.SetActive(true);  // Ativa o objeto do Canvas
        phaseText.alpha = 0;

        // Fade-in
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / 1f; // 1 segundo de fade-in
            phaseText.alpha = t;
            yield return null;
        }

        // Mantém o texto visível
        yield return new WaitForSeconds(displayTime);

        // Fade-out
        t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime / 1f; // 1 segundo de fade-out
            phaseText.alpha = t;
            yield return null;
        }

        phaseTextObject.SetActive(false); // Desativa o objeto novamente
    }
}

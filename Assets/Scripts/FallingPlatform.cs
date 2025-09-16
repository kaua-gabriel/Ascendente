using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class FallingPlatform : MonoBehaviour
{
    [Header("Timings")]
    [SerializeField] private float fallDelay = 0.5f;    // tempo em que o player precisa ficar em cima antes de cair
    [SerializeField] private float respawnDelay = 2f; // tempo para reaparecer

    [Header("Physics")]
    [SerializeField] private float fallGravity = 1f;  // gravidade aplicada quando cai
    [SerializeField] private bool requireTopCollision = true; // s� conta se o player estiver por cima
    [SerializeField] private float topOffset = 0.1f; // toler�ncia na checagem de cima

    private Rigidbody2D rb;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool isFalling = false;
    private Coroutine fallRoutine = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("FallingPlatform requer Rigidbody2D.", this);
            enabled = false;
            return;
        }

        startPosition = transform.position;
        startRotation = transform.rotation;

        // Estado inicial: parado e sem gravidade
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFalling) return;
        if (!collision.gameObject.CompareTag("Player")) return;

        // opcional: garantir que o player esteja vindo de cima
        if (requireTopCollision)
        {
            if (collision.transform.position.y < transform.position.y + topOffset)
                return;
        }

        // inicia contagem somente se o player permanecer na plataforma
        if (fallRoutine == null)
            fallRoutine = StartCoroutine(FallDelayRoutine());
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        // se o player sair antes da queda, cancela a contagem
        if (fallRoutine != null)
        {
            StopCoroutine(fallRoutine);
            fallRoutine = null;
        }
    }

    private IEnumerator FallDelayRoutine()
    {
        yield return new WaitForSeconds(fallDelay);
        fallRoutine = null;
        StartCoroutine(FallCoroutine());
    }

    private IEnumerator FallCoroutine()
    {
        isFalling = true;

        // habilita f�sica din�mica para ela cair
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = fallGravity;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // espera enquanto ela cai (ou enquanto quiser que ela fique fora)
        yield return new WaitForSeconds(respawnDelay);

        // resetar plataforma
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;

        transform.position = startPosition;
        transform.rotation = startRotation;

        isFalling = false;
    }
}

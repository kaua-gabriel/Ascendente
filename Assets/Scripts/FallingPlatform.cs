using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class FallingPlatform : MonoBehaviour
{
    [Header("Timings")]
    [SerializeField] private float fallDelay = 0f;    // cai imediatamente ao encostar
    [SerializeField] private float respawnDelay = 2f;

    [Header("Physics")]
    [SerializeField] private float fallGravity = 1f;
    [SerializeField] private bool requireTopCollision = true;
    [SerializeField] private float topOffset = 0.1f;

    private Rigidbody2D rb;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool isFalling = false;
    private Coroutine fallRoutine = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        startRotation = transform.rotation;

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

        if (requireTopCollision && !IsPlayerOnTop(collision))
            return;

        if (fallRoutine == null)
            fallRoutine = StartCoroutine(FallDelayRoutine());
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isFalling) return;
        if (!collision.gameObject.CompareTag("Player")) return;

        if (requireTopCollision && !IsPlayerOnTop(collision))
            return;

        if (fallRoutine == null)
            fallRoutine = StartCoroutine(FallDelayRoutine());
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

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

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = fallGravity;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        yield return new WaitForSeconds(respawnDelay);

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;

        transform.position = startPosition;
        transform.rotation = startRotation;

        isFalling = false;
    }

    // 🔥 Verifica se o player está por cima da plataforma
    private bool IsPlayerOnTop(Collision2D collision)
    {
        foreach (var contact in collision.contacts)
        {
            if (contact.point.y > transform.position.y + topOffset)
                return true;
        }
        return false;
    }
}

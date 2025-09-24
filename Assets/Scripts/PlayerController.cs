using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 6f;
    public int maxJumps = 2; // pulo duplo

    public PhysicsMaterial2D wallMaterial;

    private Rigidbody2D rb;
    private int jumpCount = 0;
    private float moveInput;
    private bool isGrounded = false;

    // Buffer de chão para pulo confiável
    private float groundRememberTime = 0.1f; // 100ms
    private float groundRememberCounter = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        // Pulo
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // zera só a velocidade vertical
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    void FixedUpdate()
    {
        // Movimento horizontal
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Buffer de chão
        if (groundRememberCounter > 0f)
        {
            jumpCount = 0;
            groundRememberCounter -= Time.fixedDeltaTime;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Detecta chão pela tag
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            groundRememberCounter = groundRememberTime; // reseta o buffer
        }

        // Detecta parede
        if (collision.gameObject.CompareTag("Wall") && wallMaterial != null)
        {
            GetComponent<Collider2D>().sharedMaterial = wallMaterial;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GetComponent<Collider2D>().sharedMaterial = null;
        }
    }
}

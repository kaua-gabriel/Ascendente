using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Playermanager : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 6f;

    private Rigidbody2D rb;
    private int jumpCount;
    private int maxJumps = 1;
    private float moveInput;
    private bool isGrounded = false;

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

    private void FixedUpdate()
    {
        // Movimento horizontal normal
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Reset jump count se no chão
        if (isGrounded)
        {
            jumpCount = 0;
        }

        isGrounded = false; // será setado pelo OnCollisionStay2D
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

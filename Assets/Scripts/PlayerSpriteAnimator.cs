using UnityEngine;

public class PlayerSpriteAnimator : MonoBehaviour
{
    public Sprite idleFrame;      // frame parado
    public Sprite jumpFrame;      // frame de salto
    public Sprite[] runFrames;    // frames de correr
    public float runFrameRate = 0.1f;

    private SpriteRenderer sr;
    private int runFrameIndex = 0;
    private float runTimer = 0f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = idleFrame; // começa parado
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        bool jumpPressed = Input.GetKey(KeyCode.Space);

        // Virar personagem
        if (inputX > 0) sr.flipX = false;
        if (inputX < 0) sr.flipX = true;

        if (jumpPressed)
        {
            // Pulando
            sr.sprite = jumpFrame;
            runTimer = 0f;       // reseta timer para Run
            runFrameIndex = 0;
        }
        else if (Mathf.Abs(inputX) > 0.1f)
        {
            // Andando
            AnimateRun();
        }
        else
        {
            // Parado
            sr.sprite = idleFrame;
            runTimer = 0f;
            runFrameIndex = 0;
        }
    }

    void AnimateRun()
    {
        if (runFrames.Length == 0) return;

        runTimer += Time.deltaTime;
        if (runTimer >= runFrameRate)
        {
            runTimer = 0f;
            runFrameIndex = (runFrameIndex + 1) % runFrames.Length;
            sr.sprite = runFrames[runFrameIndex];
        }
    }
}

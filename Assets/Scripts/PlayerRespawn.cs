using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPoint;

    private void Start()
    {
        // Inicialmente, o spawn � a posi��o inicial do player
        respawnPoint = transform.position;
    }

    // Atualiza o checkpoint
    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        respawnPoint = newCheckpoint;
    }

    // Mata o player e volta para o checkpoint
    public void Die()
    {
        // Aqui voc� pode adicionar anima��o ou efeito de morte
        transform.position = respawnPoint;
        // Reset de f�sica, se houver Rigidbody2D
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}

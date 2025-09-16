using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn player = other.GetComponent<PlayerRespawn>();
            if (player != null)
            {
                player.Die();
            }
        }
    }
}

using UnityEngine;

public class Cristal : MonoBehaviour
{
    public int idCristal; // 0, 1, 2, 3
    private HUDManager hudManager;

    private void Start()
    {
        // Substituindo FindObjectOfType obsoleto
        hudManager = Object.FindFirstObjectByType<HUDManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hudManager.AtivarCristal(idCristal);
            Destroy(gameObject);
        }
    }
}

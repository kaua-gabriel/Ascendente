using UnityEngine;

public class CloudMover : MonoBehaviour
{
    [SerializeField] private float speed = 2f;       // Velocidade da nuvem
    [SerializeField] private float resetPositionX = -15f; // Posição X para resetar
    [SerializeField] private float startPositionX = 15f;  // Posição inicial de retorno

    private void Update()
    {
        // Move a nuvem para a esquerda
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Se passou do limite, volta para o outro lado
        if (transform.position.x < resetPositionX)
        {
            Vector3 newPos = transform.position;
            newPos.x = startPositionX;
            transform.position = newPos;
        }
    }
}

using UnityEngine;

public class RotateObject    : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidade em graus por segundo

    void Update()
    {
        // Gira apenas no eixo X
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}

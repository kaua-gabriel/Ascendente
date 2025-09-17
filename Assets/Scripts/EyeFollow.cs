using UnityEngine;

public class EyeFollow : MonoBehaviour
{
    public Transform pupil;         // Pupila do olho
    public float maxDistance = 0.03f; // Limite do movimento da pupila
    public float smoothSpeed = 2f;   // Suavização

    private Vector3 startLocalPos;
    private Transform player;        // Referência ao player ativo

    void Start()
    {
        if (pupil != null)
            startLocalPos = pupil.localPosition;
    }

    void Update()
    {
        // Se ainda não achou o player ativo, procura a cada frame
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }

        if (player == null || pupil == null) return;

        // Calcula direção em 2D (X e Y)
        Vector3 direction = player.position - transform.position;
        direction.z = 0;
        direction = direction.normalized;

        // Posição desejada da pupila
        Vector3 targetLocalPos = startLocalPos + direction * maxDistance;

        // Move suavemente
        pupil.localPosition = Vector3.Lerp(pupil.localPosition, targetLocalPos, Time.deltaTime * smoothSpeed);
    }
}

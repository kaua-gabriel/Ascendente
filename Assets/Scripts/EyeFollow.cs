using UnityEngine;

public class EyeFollow : MonoBehaviour
{
    public Transform pupil;         // Pupila do olho
    public float maxDistance = 0.03f; // Limite do movimento da pupila
    public float smoothSpeed = 2f;   // Suaviza��o

    private Vector3 startLocalPos;
    private Transform player;        // Refer�ncia ao player ativo

    void Start()
    {
        if (pupil != null)
            startLocalPos = pupil.localPosition;
    }

    void Update()
    {
        // Se ainda n�o achou o player ativo, procura a cada frame
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }

        if (player == null || pupil == null) return;

        // Calcula dire��o em 2D (X e Y)
        Vector3 direction = player.position - transform.position;
        direction.z = 0;
        direction = direction.normalized;

        // Posi��o desejada da pupila
        Vector3 targetLocalPos = startLocalPos + direction * maxDistance;

        // Move suavemente
        pupil.localPosition = Vector3.Lerp(pupil.localPosition, targetLocalPos, Time.deltaTime * smoothSpeed);
    }
}

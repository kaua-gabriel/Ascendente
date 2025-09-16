using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movimento")]
    [SerializeField] private float moveDistance = 3f; // dist�ncia que ela vai percorrer (em Y)
    [SerializeField] private float speed = 2f;        // velocidade do movimento
    [SerializeField] private bool startGoingUp = true; // define se come�a subindo

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool goingUp;

    private void Start()
    {
        startPosition = transform.position;
        goingUp = startGoingUp;
        UpdateTarget();
    }

    private void Update()
    {
        // mover at� o destino
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        // se chegou no destino, inverte dire��o
        if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
        {
            goingUp = !goingUp;
            UpdateTarget();
        }
    }

    private void UpdateTarget()
    {
        if (goingUp)
            targetPosition = startPosition + Vector3.up * moveDistance;
        else
            targetPosition = startPosition;
    }
}

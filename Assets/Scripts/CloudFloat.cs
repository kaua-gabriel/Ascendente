using UnityEngine;

public class CloudFloat : MonoBehaviour
{
    public float amplitude = 0.5f; // altura do movimento
    public float speed = 1f;       // velocidade

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}

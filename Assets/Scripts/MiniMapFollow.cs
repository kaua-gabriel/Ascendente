using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        Vector3 pos = player.position;
        pos.z = transform.position.z; // mant�m a dist�ncia da c�mera
        transform.position = pos;
    }
}

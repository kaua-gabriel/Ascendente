using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        Vector3 pos = player.position;
        pos.z = transform.position.z; // mantém a distância da câmera
        transform.position = pos;
    }
}

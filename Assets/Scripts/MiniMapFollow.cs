using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    private Transform player; // Player ativo

    void LateUpdate()
    {
        // Se ainda não achou o player, procura a cada frame
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }

        if (player == null) return; // não faz nada se não encontrar player

        // Mantém a posição da câmera em relação ao player
        Vector3 pos = player.position;
        pos.z = transform.position.z; // mantém a distância da câmera
        transform.position = pos;
    }
}
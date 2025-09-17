using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    private Transform player; // Player ativo

    void LateUpdate()
    {
        // Se ainda n�o achou o player, procura a cada frame
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }

        if (player == null) return; // n�o faz nada se n�o encontrar player

        // Mant�m a posi��o da c�mera em rela��o ao player
        Vector3 pos = player.position;
        pos.z = transform.position.z; // mant�m a dist�ncia da c�mera
        transform.position = pos;
    }
}
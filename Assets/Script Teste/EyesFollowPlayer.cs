using UnityEngine;

public class EyesFollowPlayer : MonoBehaviour
{
    public float maxDistance = 0.1f; // limite do movimento da pupila
    private Transform[] pupils;

    void Start()
    {
        // Pega todas as pupilas na cena (com tag "Pupila")
        GameObject[] pupilObjects = GameObject.FindGameObjectsWithTag("Pupila");
        pupils = new Transform[pupilObjects.Length];
        for (int i = 0; i < pupilObjects.Length; i++)
            pupils[i] = pupilObjects[i].transform;
    }

    void Update()
    {
        // Procura o player ativo
        GameObject activePlayer = GameObject.FindGameObjectWithTag("Player"); // Tag Player no player ativo
        if (activePlayer == null || pupils == null) return;

        Transform player = activePlayer.transform;

        foreach (Transform pupil in pupils)
        {
            // Move a pupila em direção ao player ativo
            Vector3 dir = (player.position - pupil.parent.position).normalized;
            pupil.localPosition = dir * maxDistance;
        }
    }
}

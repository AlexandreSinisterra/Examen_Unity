
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    public Transform player;

    public float detectionRange = 5f;

    public float speed = 2f;

    private string currentState = "lejos";

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("no se ha encontrado un jugador");
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > detectionRange)
        {
            currentState = "lejos";

    //        Debug.LogWarning("jugador demasiado lejos");

        }
        else
        {
            currentState = "cerca";

            Vector3 direction = (player.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;

 //           Debug.LogWarning("dentro del rango, acercandose");

        }
    }
}


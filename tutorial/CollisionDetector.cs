using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public int damagePerHit = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aquí declaras 'player' y funciona bien
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.TakeDamage(damagePerHit);
            }

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // SOLUCIÓN: Tienes que volver a buscar el componente 
            // o declararlo de nuevo para este método.
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            
            if (player != null)
            {
                if (player.matar()){
                Debug.Log("El enemigo muere porque el jugador ganó.");
                Destroy(gameObject);
                } else {
                player.TakeDamage(1);
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ya no hay colision.");
        }
    }
}
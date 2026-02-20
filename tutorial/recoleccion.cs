using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Avisamos al jugador que recogió algo
            other.GetComponent<PlayerController>().CollectPickup();

            // Destruimos el objeto pickup
            Destroy(gameObject);
        }
    }
}
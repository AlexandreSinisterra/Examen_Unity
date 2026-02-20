using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar la partida

public class PlayerController : MonoBehaviour
{
    public float forceAmount = 10f;
    public int health = 100;
    public int pickupsCollected = 0;
    public int totalPickups =12; // Ajusta esto al número de pickups en tu escena
    public bool victoria = false;

    private Rigidbody rb;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isDead) return; // Si está muerto, no se mueve

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * forceAmount);
    }

    // Método para recibir daño
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Vida restante: " + health);

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    // Método para recoger objetos
    public void CollectPickup()
    {
        pickupsCollected++;
        Debug.Log("Pickups: " + pickupsCollected + "/" + totalPickups);

        if (pickupsCollected >= totalPickups)
        {
            Win();
        }
    }

    public bool matar (){
        return victoria;
    }

    void Die()
    {
        isDead = true;
        Debug.Log("💥 GAME OVER 💥");
        gameObject.SetActive(false);
        // Aquí podrías cargar una escena de derrota o reiniciar
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Win()
    {
        victoria = true;
        Debug.Log("🏆 ¡VICTORIA! Has recogido todo.");
    }
}
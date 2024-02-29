using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement; // A reference to our PlayerMovement script
    private AudioSource failSound;
    private AudioSource successSound; // Corrección de typo en el nombre de la variable

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        failSound = audioSources[0]; // Asume que el primer AudioSource es el sonido de fallo
        successSound = audioSources[1]; // Asume que el segundo AudioSource es el sonido de éxito
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        // Check if the object we collided with has a tag called "Obstacle".
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false; // Disable the players movement.
            failSound.Play(); // Reproduce el sonido de fallo
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    // Método para detectar cuando el jugador atraviesa un Trigger
    void OnTriggerEnter(Collider other)
    {
        // Verifica si el Trigger tiene la etiqueta deseada, "TriggerSuccess"
        if (other.tag == "TriggerSuccess")
        {
            successSound.Play(); // Reproduce el sonido de éxito
        }
    }
}

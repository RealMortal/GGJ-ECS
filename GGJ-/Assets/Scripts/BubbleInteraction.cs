using UnityEngine;

public class BubbleInteraction : MonoBehaviour
{
    public AudioClip bubblePopSound; // Drag the audio clip in the Inspector
    private AudioSource audioSource;
    public GameOver gameOver;
    void Start()
    {


       
        // Add an AudioSource component to the bubble if it doesn't exist
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the bubble pop sound
        audioSource.clip = bubblePopSound;
        audioSource.playOnAwake = false; // Ensure it doesn't play automatically
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collided object has the tag "Enemy" or "Obstacle"
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Obstacle"))
        {
            // Play the pop sound
            audioSource.Play();

            // Destroy the bubble after the sound finishes
            Destroy(gameObject, bubblePopSound.length);
            gameOver.GG();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Heal"))
        {
            // Access the BubbleDecay script and heal the bubble
            BubbleDecay bubbleDecay = gameObject.GetComponent<BubbleDecay>();
            if (bubbleDecay != null)
            {
                bubbleDecay.Heal(5); // Heal by 8 points
            }

            // Destroy the healing object
            Destroy(other.gameObject);
        }
    }
}

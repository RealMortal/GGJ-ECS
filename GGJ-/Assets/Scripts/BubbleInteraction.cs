using UnityEngine;

public class BubbleInteraction : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collided object has the tag "Enemy" or "Obstacle"
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Obstacle"))
        {

            print("We collided");
            // Destroy the bubble (this GameObject)
            Destroy(gameObject);

            // Optionally, destroy the other object as well
            // Destroy(collision.gameObject);
        }
    }

}

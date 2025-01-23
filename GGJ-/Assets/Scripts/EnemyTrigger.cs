using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject rock;               // Reference to the falling rock GameObject
    public Sprite newSprite;              // New sprite to change to
    private Rigidbody2D rb;               // Rigidbody of the rock
   
    private void Start()
    {
        // Get the Rigidbody2D component from the rock
        rb = rock.GetComponent<Rigidbody2D>();

        // Ensure Rigidbody2D is initially Kinematic to prevent falling
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the trigger
        if (other.CompareTag("Player"))
        {
            // Change the sprite of the rock
            if (rock.GetComponent<SpriteRenderer>() != null && newSprite != null)
            {
                rock.GetComponent<SpriteRenderer>().sprite = newSprite;
            }

            // Change Rigidbody2D to Dynamic to enable falling
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
          

        }
    }

   
}

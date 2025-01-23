using UnityEngine;

public class EnemyPeriodicMovement : MonoBehaviour
{
    public float amplitude = 2f;    // The height of the movement (half the total range)
    public float frequency = 1f;   // The speed of the movement (oscillations per second)
    private Vector3 initialPosition; // The starting position of the enemy
    public bool reverseMovement;
    void Start()
    {
        // Store the initial position of the enemy
        initialPosition = transform.position;
    }

    void Update()
    {

        if (reverseMovement)
        {
            // Calculate the new Y position using a sine wave
            float newY = initialPosition.y - Mathf.Sin(Time.time * frequency * Mathf.PI * 2f) * amplitude;

            // Update the position of the enemy
            transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);

        }
        else
        {
            // Calculate the new Y position using a sine wave
            float newY = initialPosition.y + Mathf.Sin(Time.time * frequency * Mathf.PI * 2f) * amplitude;

            // Update the position of the enemy
            transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
        }


      
    }
}

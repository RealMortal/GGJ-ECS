using UnityEngine;

public class CatJump : MonoBehaviour
{
    public Transform player;          // Reference to the player object
    public float detectionRadius = 5f; // Radius within which the player triggers the jump
    public float angleOfIncline = 45f; // Angle of the jump in degrees
    public float initialVelocity = 10f; // Initial speed of the jump

    private const float gravity = 9.81f;
    private bool isJumping = false;
    private float elapsedTime = 0f;
    private Vector3 startPosition;
    private AudioSource audioSource;
    public AudioClip bubblePopSound; // Drag the audio clip in the Inspector

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the bubble pop sound
        audioSource.clip = bubblePopSound;
        audioSource.playOnAwake = false; // Ensure it doesn't play automatically
    }

    void Update()
    {

       

        if (player != null && !isJumping && IsPlayerWithinRadius())
        {
            StartJump();
            audioSource.Play();

            detectionRadius = 0f;
        }

        if (isJumping)
        {
            SimulateJump();
        }
    }

    void StartJump()
    {
        // Convert angle to radians
        angleOfIncline = angleOfIncline * Mathf.Deg2Rad;

        // Set the starting position
        startPosition = transform.position;

        // Reset elapsed time
        elapsedTime = 0f;

        // Mark as jumping
        isJumping = true;
    }

    void SimulateJump()
    {
        // Increment elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate new position
        float x = initialVelocity * Mathf.Cos(angleOfIncline) * elapsedTime;
        float y = (initialVelocity * Mathf.Sin(angleOfIncline) * elapsedTime) - (0.5f * gravity * Mathf.Pow(elapsedTime, 2));

        // Update position
        transform.position = new Vector3(startPosition.x - x, startPosition.y + y, transform.position.z);

        // Stop jump when hitting the ground
        if (transform.position.y <= startPosition.y)
        {
            transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
            isJumping = false;
        }
    }

    bool IsPlayerWithinRadius()
    {
        // Check if player is within detection radius
        float distance = Vector3.Distance(transform.position, player.position);
        return distance <= detectionRadius;
    }

    // Optional: Visualize detection radius in Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

  
}

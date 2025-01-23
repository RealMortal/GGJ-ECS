using UnityEngine;

public class BeeCircularMovement : MonoBehaviour
{
    public float radius = 2f;       // Radius of the circular path
    public float speed = 2f;        // Speed of the bee's circular movement
    public bool isClockwise = true; // Toggle between clockwise and counterclockwise movement
    private Vector3 centerPosition; // The center of the circular path
    private float angle;            // Current angle of the bee on the circular path

    void Start()
    {
        // Set the center of the circular path to the bee's initial position
        centerPosition = transform.position;
    }

    void Update()
    {
        // Increment or decrement the angle based on the direction
        angle += (isClockwise ? -1 : 1) * speed * Time.deltaTime;

        // Calculate the new X and Y positions using Sin and Cos
        float newX = centerPosition.x + Mathf.Cos(angle) * radius;
        float newY = centerPosition.y + Mathf.Sin(angle) * radius;

        // Update the bee's position
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}

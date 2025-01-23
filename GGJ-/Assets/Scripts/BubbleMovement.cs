using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public float movementSpeed = 10f; // Speed for both horizontal and vertical movement

    void Update()
    {
        // Get input for both vertical and horizontal directions
        float verticalInput = Input.GetAxis("Vertical");   // W/S or Up/Down keys
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right keys

        // Calculate new position
        Vector3 newPosition = transform.position +
                              Vector3.up * verticalInput * movementSpeed * Time.deltaTime +
                              Vector3.right * horizontalInput * movementSpeed * Time.deltaTime;

        // Apply the new position to the object
        transform.position = newPosition;
    }
}

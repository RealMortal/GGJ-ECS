using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float verticalSpeed = 5f;
    public float maxHeight = 4f;
    public float minHeight = -4f;

    void Update()
    {
        float input = Input.GetAxis("Vertical"); // W/S or Up/Down keys
        Vector3 newPosition = transform.position + Vector3.up * input * verticalSpeed * Time.deltaTime;

        transform.position = newPosition;

        transform.position += Vector3.right * forwardSpeed * Time.deltaTime;

    }

}

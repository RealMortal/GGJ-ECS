using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target; // Assign the player's Transform in the Inspector
    public Vector3 offset;   // Offset to position the camera relative to the bubble
    void LateUpdate()
    {
       
       if(target != null)
        {
            transform.position = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);
        }
            
        
    }
}

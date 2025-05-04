using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Focal point of the camera
    public Transform target;
    // Distance of camera from target
    public Vector3 offset = new Vector3(0.0f, 0.0f, -20.0f);
    // Time to slow and focus on target
    private float _smoothTime = 0.2f;
    // Speed of the camera
    private Vector3 _velocity = Vector3.zero;

    private void FixedUpdate()
    {
        SmoothMove();
    }

    private void SmoothMove()
    {
        // Get the position of the target and apply a smooth movement to the center of the camera towards the player
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
    }
    
}

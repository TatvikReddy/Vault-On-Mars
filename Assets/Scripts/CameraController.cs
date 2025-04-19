using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    
    private Vector3 _offset = new Vector3(0.0f, 0.0f, -10.0f);
    private float _smoothTime = 0.5f;
    private Vector3 _velocity = Vector3.zero;

    private void FixedUpdate()
    {
        SmoothMove();
    }

    private void SmoothMove()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
    }
    
}

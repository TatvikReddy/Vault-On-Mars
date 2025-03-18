using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float speed = 5.0f;
    
    private Vector2 _newVelocity;
    

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        _newVelocity.Set(xInput * speed, rb.linearVelocity.y);
        rb.linearVelocity = _newVelocity;
    }
    
}

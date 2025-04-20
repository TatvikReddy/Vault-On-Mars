using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    // Reference to the rigidbody of the player
    public Rigidbody2D rb;
    // Reference to the speed of the player
    public float speed = 5.0f;
    // Variable to hold and save velocity between updates
    private Vector2 _newVelocity;
    

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        // Get horizontal input (AKA "A", "D", Left Arrow, and Right Arrow)
        float xInput = Input.GetAxis("Horizontal");
        _newVelocity.Set(xInput * speed, rb.linearVelocity.y);
        
        // After setting newVelocity apply it to the linear velocity of the rigidbody
        rb.linearVelocity = _newVelocity;
    }
    
}

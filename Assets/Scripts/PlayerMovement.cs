using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D body;

    // Update is called once per frame
    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontal, 0.0f) * speed;
    }
}

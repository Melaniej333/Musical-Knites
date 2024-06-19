using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float gravity = -9.8f;
    public Vector2 velocity;
    public float jumpVelocity = 20;
    public float groundHeight = 0;
    public bool isGrounded = false;
    public float forwardSpeed = 5.0f; // Speed at which the player moves forward
    public float speedFactor = 1.0f; // Factor to control the overall speed of the player
    public Vector3 normalScale = new Vector3(1.0f, 1.0f, 1.0f); // Normal scale of the player
    public Vector3 duckScale = new Vector3(1.0f, 0.5f, 1.0f); // Scale of the player when ducking

    // Start is called before the first frame update
    void Start()
    {
        // Initialize velocity
        velocity = Vector2.zero;
        // Set the initial scale to normal
        transform.localScale = normalScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Jump up
                velocity.y = jumpVelocity * speedFactor;
                isGrounded = false;
            }
        }

        // Check for down arrow key press to duck
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localScale = duckScale;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.localScale = normalScale;
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        // Apply gravity
        velocity.y += gravity * Time.fixedDeltaTime;

        // Update vertical position
        pos.y += velocity.y * Time.fixedDeltaTime;

        // Check if the player has hit the ground
        if (pos.y <= groundHeight)
        {
            pos.y = groundHeight;
            isGrounded = true;
            velocity.y = 0; // Reset vertical velocity when grounded
        }

        // Move the player forward continuously
        pos.x += forwardSpeed * speedFactor * Time.fixedDeltaTime;

        // Update the player's position
        transform.position = pos;
    }
}

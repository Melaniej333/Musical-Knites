using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasCollided = false; // Flag to check if the object has already collided

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the object.");
        }
    }

    private void FixedUpdate()
    {
        if (hasCollided && rb != null)
        {
            rb.velocity = Vector2.zero; // Stop the object's movement
            rb.angularVelocity = 0f;    // Stop any rotation
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Runs at the first time of collision
        // This collision gives information about the object we touch
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Collided with Player");
            hasCollided = true;
            if (rb != null)
            {
                rb.velocity = Vector2.zero; // Stop the object's movement immediately
                rb.angularVelocity = 0f;    // Stop any rotation immediately
                rb.isKinematic = true;      // Prevent further physics interactions
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Runs as soon as the collision ends
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Stopped colliding with Player");
            hasCollided = false;
            if (rb != null)
            {
                rb.isKinematic = false; // Allow further physics interactions if needed
            }
        }
    }
}

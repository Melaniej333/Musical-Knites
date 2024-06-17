using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving1 : MonoBehaviour
{
    public float speed = 2.0f; // Speed at which the ground moves
    public float resetPosition = -10.0f; // Position at which the ground resets
    public float startPosition = 10.0f; // Starting position of the ground

    // Update is called once per frame
    void Update()
    {
        // Move the ground to the left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Check if the ground has moved past the reset position
        if (transform.position.x <= resetPosition)
        {
            // Reset the position of the ground to the starting position
            transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
        }
    }
}

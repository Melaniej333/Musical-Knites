using UnityEngine;

public class TriangleDisappearance : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the character
        if (other.CompareTag("Player"))
        {
            // Disable the triangle GameObject
            gameObject.SetActive(false);
        }
    }
}


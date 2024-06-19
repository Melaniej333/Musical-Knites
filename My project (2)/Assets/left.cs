using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 5f; // Speed at which the triangle moves

    void Update()
    {
        // Move the triangle to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow1 : MonoBehaviour
{
    
    private Vector2 offset = new Vector2(0f, 0f);
    private float smoothTime = 0.25f;
    private Vector2 velocity = Vector2.zero;

    [SerializeField] private Transform target;

    private void Update()
    {
        Vector2 targetPosition = target.position;// * offset;
        transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

}
*/
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // The player transform to follow
    public Vector3 offset; // Offset from the player position
    public float followSpeed = 5.0f; // Speed at which the camera follows


    void LateUpdate()
    {
        Vector3 targetPosition = playerTransform.position + offset;
        Debug.Log("Target Position: " + targetPosition);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        Debug.Log("Camera Position: " + transform.position);
    }

}

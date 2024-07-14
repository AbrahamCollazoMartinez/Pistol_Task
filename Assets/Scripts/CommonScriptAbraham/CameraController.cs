using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothTime = 0.15f;


    private Vector3 velocity = Vector3.zero;
    private Vector3 desiredPosition;
    private Vector3 calculatedPosition;

    private void FixedUpdate()
    {
        if (player != null)
        {
            // Calculate the desired camera position
            desiredPosition = player.position;

            // Smoothly lerp the camera position towards the desired position
            calculatedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
            calculatedPosition.z = transform.position.z;
            transform.position = calculatedPosition;
        }
    }
}

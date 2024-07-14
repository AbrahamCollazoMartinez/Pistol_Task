using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _rotationSpeed;

    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private PlayerDetection playerDetection;
    [SerializeField] private UnityEvent<bool> onWalking;
    private Vector2 targetDirection;


    private void FixedUpdate()
    {
        UpdateTargetDirection();
        Rotate();
        SetVelocity();
    }
    private void UpdateTargetDirection()
    {

        if (playerDetection.AwareOfPlayer)
        {

            targetDirection = playerDetection.DirectionToPlayer;

        }
        else
        {

            targetDirection = Vector2.zero;
        }
    }

    private void Rotate()
    {
        if (targetDirection == Vector2.zero) return;

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        rigidbody.SetRotation(rotation);

    }

    private void SetVelocity()
    {

        if (targetDirection == Vector2.zero)
        {
            rigidbody.velocity = Vector2.zero;
            onWalking?.Invoke(false);
        }
        else
        {
            rigidbody.velocity = transform.up * _speed;
            onWalking?.Invoke(true);

        }

    }
}



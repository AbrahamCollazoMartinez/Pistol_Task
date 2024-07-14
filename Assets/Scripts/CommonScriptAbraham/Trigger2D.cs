using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Trigger2D : MonoBehaviour
{
    [SerializeField] private string tag;
    [SerializeField] private UnityEvent onCollision, onTrigger;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(tag))
        {
            onCollision.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(tag))
        {
            onTrigger.Invoke();
        }
    }
}

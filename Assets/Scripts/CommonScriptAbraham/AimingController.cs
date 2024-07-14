using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AimingController : MonoBehaviour
{
    [SerializeField] private float radius = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CharacterController player_controller;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float aiming_speed;



    //private cache data
    private FocusItem nearestObject;
    private bool isAiming = false;
    private Collider2D[] colliders_cast;
    private float shortestDistance;
    private FocusItem closestObject;
    private FocusItem check_component;
    private Vector2 direction_rotation;
    private float angle_rotation;
    private float targetAngle_rotation;
    private PriorityFocus priorityClosest;


    void Start()
    {
        AdjustSpriteScale();
    }

    void FixedUpdate()
    {
        FindNearestObject();
        AdjustSpriteScale();
        HandleRotation();
    }

    void FindNearestObject()
    {

        colliders_cast = Physics2D.OverlapCircleAll(transform.position, radius);
        shortestDistance = Mathf.Infinity;
        closestObject = null;
        check_component = null;
        FocusItem closestFocusItem = null;

        if (colliders_cast.Length > 0)
        {
            foreach (Collider2D collider in colliders_cast)
            {
                if (collider.gameObject != gameObject)
                {
                    float distance = Vector3.Distance(transform.position, collider.transform.position);
                    check_component = collider.gameObject.GetComponent<FocusItem>();
                    if (check_component != null && check_component.CanFocus)
                    {
                        if (closestFocusItem == null || check_component.Priority > closestFocusItem.Priority)
                        {
                            closestFocusItem = check_component;
                            shortestDistance = distance;
                            closestObject = check_component;
                        }
                        else if (check_component.Priority == closestFocusItem.Priority && distance < shortestDistance)
                        {
                            closestFocusItem = check_component;
                            shortestDistance = distance;
                            closestObject = check_component;
                        }
                    }
                }
            }
        }
        else
        {
            closestObject = null;
        }

        nearestObject = closestObject;

        if (closestObject == null)
        {
            isAiming = false;
            player_controller.CanRotate = true;
        }
        else
        {
            isAiming = true;
            player_controller.CanRotate = false;
        }
    }

    void AdjustSpriteScale()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.transform.localScale = new Vector3(radius * 2.4f, radius * 2.4f, spriteRenderer.transform.localScale.z);
        }
    }

    private void HandleRotation()
    {
        if (!isAiming) return;
        direction_rotation = (Vector2)(nearestObject.transform.position - transform.position);

        angle_rotation = Mathf.Atan2(direction_rotation.y, direction_rotation.x) * Mathf.Rad2Deg;

        angle_rotation -= 90f;


        targetAngle_rotation = Mathf.LerpAngle(rb.rotation, angle_rotation, Time.deltaTime * aiming_speed);
        rb.MoveRotation(targetAngle_rotation);
    }




#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

        if (nearestObject != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, nearestObject.transform.position);
        }
    }
#endif
}

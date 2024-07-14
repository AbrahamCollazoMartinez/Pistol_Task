using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_TouchActions : MonoBehaviour
{
    private ITouchable touchable;
    private void Update()
    {
        // Detect touches or clicks
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector2 touchPos;

            // Check if it's a touch or a click
            if (Input.touchCount > 0)
            {
                touchPos = Camera.main.ScreenPointToRay(Input.GetTouch(0).position).origin;
            }
            else
            {
                touchPos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            }

            Collider2D hit = Physics2D.OverlapPoint(touchPos);

            if (hit != null)
            {
                touchable = hit.gameObject.GetComponent<ITouchable>();
                if (touchable != null)
                {
                    touchable.Action();
                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularLayout : MonoBehaviour
{
    public float radius = 5f;
    public float spacing = 1f;
    public Axis axis = Axis.Y;

    private void Start()
    {
        UpdateLayout();
    }

    private void UpdateLayout()
    {
        int childCount = transform.childCount;
        if (childCount == 0)
            return;

        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            float angle = (float)i / childCount * 2f * Mathf.PI;
            Vector3 position = Vector3.zero;

            switch (axis)
            {
                case Axis.X:
                    position.x = Mathf.Cos(angle) * radius;
                    position.z = Mathf.Sin(angle) * radius;
                    break;
                case Axis.Y:
                    position.y = Mathf.Cos(angle) * radius;
                    position.z = Mathf.Sin(angle) * radius;
                    break;
                case Axis.Z:
                    position.x = Mathf.Cos(angle) * radius;
                    position.y = Mathf.Sin(angle) * radius;
                    break;
            }

            child.localPosition = position + transform.position;
            child.localRotation = Quaternion.Euler(0f, angle * Mathf.Rad2Deg + 90f, 0f);
        }
    }

    public enum Axis
    {
        X,
        Y,
        Z
    }
}

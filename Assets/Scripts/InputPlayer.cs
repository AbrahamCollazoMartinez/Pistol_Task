using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

//in this way we can replace easily the origin of the inputs
public class InputPlayer : MonoBehaviour
{
    //inspector variables
    [SerializeField] private DynamicJoystick joystick;
    [SerializeField] private UnityEvent<InputAction> onActionPressed;

    //getters
    private Vector2 input = new Vector2();
    public Vector2 Input { get { return input; } }
    public UnityEvent<InputAction> OnActionPressed { get { return onActionPressed; } }

    private bool isActive = true;
    public bool IsActive { get { return isActive; } set { isActive = value; } }


    //static
    public static InputPlayer Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {

        input.x = joystick.Horizontal;
        input.y = joystick.Vertical;
    }

}

public enum InputAction
{
    Shoot,
    Pistol,
    Shotgun
}

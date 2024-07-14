using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    //inspetor variables
    [SerializeField] private InputPlayer input_player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float accelerationTime = 0.5f;
    [SerializeField] private float decelerationTime = 0.5f;
    [SerializeField] private float rotation_speed = 10f;
    [SerializeField] private UnityEvent<bool> onMove;

    //private and cache methods
    private Vector2 targetVelocity;
    private Vector2 currentVelocity;
    private Vector2 input_readed;


    //getters
    private bool can_move = true;
    public bool CanMove { get => can_move; set => can_move = value; }

    private bool can_rotate = true;
    public bool CanRotate { get => can_rotate; set => can_rotate = value; }

    private void FixedUpdate()
    {
        CheckInput();
        HandleMovement();
        HandleRotation();
    }

    private void CheckInput()
    {
        if (can_move)
        {
            input_readed = input_player.Input;
        }
        else
        {
            input_readed = Vector2.zero;
        }
    }

    private void HandleMovement()
    {
        targetVelocity = new Vector2(input_readed.x, input_readed.y) * moveSpeed;
        currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, accelerationTime * Time.deltaTime);
        rb.velocity = currentVelocity;

        if (input_player.Input == Vector2.zero)
        {
            onMove?.Invoke(false);
        }
        else
        {
            onMove?.Invoke(true);
        }

    }

    private void HandleRotation()
    {
        if (!can_rotate) return;

        if (input_player.Input != Vector2.zero)
        {

            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, input_player.Input);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotation_speed);


            rb.MoveRotation(rotation);

        }
    }
}
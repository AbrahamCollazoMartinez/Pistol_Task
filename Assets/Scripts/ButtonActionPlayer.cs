using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActionPlayer : MonoBehaviour
{
    [SerializeField] private InputAction action_player;

    public void OnPressed()
    {
        InputPlayer.Instance?.OnActionPressed?.Invoke(action_player);
    }
}

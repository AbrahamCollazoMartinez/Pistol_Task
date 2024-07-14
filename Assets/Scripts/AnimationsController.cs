using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    [SerializeField] private Animator anim_controller;
    [SerializeField] private string name_param_walking, name_param_shoot;


    public void IsWalking(bool state)
    {
        if (anim_controller.GetBool(name_param_walking) != state)
        {
            anim_controller.SetBool(name_param_walking, state);
        }
    }

    public void TriggerShoot()
    {
        anim_controller.SetTrigger(name_param_shoot);
    }
}

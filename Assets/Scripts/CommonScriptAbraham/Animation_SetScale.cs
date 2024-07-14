using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Animation_SetScale : MonoBehaviour
{
    public float scale = 1;
    public float speed = 0.5f;
    Tween anim_hidder;
    public void SetToOne(bool state)
    {

        if (anim_hidder != null)
            anim_hidder.Kill();

        if (state)
        {
            anim_hidder = transform.DOScale(1, speed).SetEase(Ease.InOutQuint);
        }
        else
        {
            anim_hidder = transform.DOScale(scale, speed).SetEase(Ease.InOutQuint);
        }
    }
}

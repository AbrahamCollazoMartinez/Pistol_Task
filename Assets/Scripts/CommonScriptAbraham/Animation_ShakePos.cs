using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Animation_ShakePos : MonoBehaviour
{
    [SerializeField] private float strength;
    Tween anim_shake;
    public void ShakeAnim()
    {
        if (anim_shake != null)
            anim_shake.Kill();

        this.transform.localEulerAngles = Vector3.zero;

        anim_shake = transform.DOShakePosition(0.7f, strength).SetEase(Ease.InOutElastic);
    }
}

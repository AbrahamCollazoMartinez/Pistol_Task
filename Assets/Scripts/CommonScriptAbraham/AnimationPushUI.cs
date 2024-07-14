using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimationPushUI : MonoBehaviour
{
    [SerializeField] private float SizePunch_Anim = 0.9f;
    [SerializeField] private bool use_start_size_object = false;


    private bool AnimationAbleToRun = true;
    private Vector3 original_size = Vector3.one;



    private void OnEnable()
    {
        if (use_start_size_object)
        {
            original_size = this.transform.localScale;
        }
    }

    public void ButtonAnimationInteract()
    {
        if (AnimationAbleToRun)
        {
            AnimationAbleToRun = false;

            this.gameObject.transform.DOScale(SizePunch_Anim * original_size, 0.1f).OnComplete(() =>
            {

                this.gameObject.transform.DOScale(original_size, 0.1f).OnComplete(() =>
                {

                    AnimationAbleToRun = true;


                }).SetUpdate(true);

            }).SetUpdate(true);
        }

    }

}

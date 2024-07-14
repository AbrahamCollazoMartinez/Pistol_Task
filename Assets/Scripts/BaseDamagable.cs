using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseDamagable : MonoBehaviour, IDamagable
{

    [SerializeField] private float life = 100f;
    [SerializeField] private UnityEvent onDamage, onKilled;



    public float Life { get => life; }


    public virtual void Damage(float amount)
    {
        life = Mathf.Clamp(life - amount, 0, life);
        onDamage?.Invoke();

        if (life == 0)
        {
            onKilled?.Invoke();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private float damage = 0;
	public float Damage
	{
		get => damage;
		set => damage = value;
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		PoolManager.Instance.ReturnBullet(this);
	}
}

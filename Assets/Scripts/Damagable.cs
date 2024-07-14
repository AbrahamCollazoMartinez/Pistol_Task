using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : BaseDamagable
{
	[SerializeField] private ParticleSystem _prefab_impact_effect;
	[SerializeField] private GameObject _prefab_explotion_effect;

	//cache
	private Bullet bullet_;



	private void OnCollisionEnter2D(Collision2D other)
	{
		bullet_ = other.gameObject.GetComponent<Bullet>();

		if (bullet_ != null)
		{
			Damage(bullet_.Damage);

			ContactPoint2D contact = other.contacts[0];
			Instantiate(_prefab_impact_effect, contact.point, Quaternion.identity);
		}
	}

	public void DestoyItem()
	{
		Instantiate(_prefab_explotion_effect, this.transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPassage : MonoBehaviour
{
	public int damage = 10;
	public string triggerAttack = "Attack";
	public string triggerKill = "Kill";

	public HealthBase healthBase;

	private void Awake()
	{
		if (healthBase != null)
		{
			healthBase.OnKill += OnEnemyKill;

		}
	}

	private void OnEnemyKill()
	{
		healthBase.OnKill -= OnEnemyKill;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		var health = collision.gameObject.GetComponent<HealthBase>();
		if (health != null)
		{
			health.Damage(damage);
		}
	}
}

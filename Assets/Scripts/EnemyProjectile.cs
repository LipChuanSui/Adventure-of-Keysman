using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private float resetTime;
	private float lifeTime;

	public void ActivateProjectile()
	{
		lifeTime = 0;
		gameObject.SetActive(true);
	}

	private void Update()
	{
		float moveSpeed = speed * Time.deltaTime;
		transform.Translate(moveSpeed, 0, 0);

		lifeTime += Time.deltaTime;
		if(lifeTime > resetTime)
		{
			gameObject.SetActive(false);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(!collision.gameObject.CompareTag("Trap") || !collision.gameObject.CompareTag("NoAction"))
			gameObject.SetActive(false);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!collision.gameObject.CompareTag("Trap") || !collision.gameObject.CompareTag("NoAction"))
			gameObject.SetActive(false);

	}

}

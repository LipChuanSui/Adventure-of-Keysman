using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTRap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;
    private float cooldownTImer;

    private void Attack()
	{
        cooldownTImer = 0;

        arrows[FindArrow()].transform.position = firePoint.position;
        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();

    }

    private int FindArrow()
	{
		for (int i = 0; i < arrows.Length; i++)
		{
            if (!arrows[i].activeInHierarchy)
                return i;
		}
        return 0;
	}


    // Update is called once per frame
    void Update()
    {
        cooldownTImer += Time.deltaTime;

        if (cooldownTImer >= attackCooldown)
            Attack();
    }
}

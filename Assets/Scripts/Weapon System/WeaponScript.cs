using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    //interpolated from youtube 
    
    public Transform attackPoint;
    public float attackRange = 3f;
    public LayerMask enemyLayers;
    public float damageAmount = 1f;
    public String trigger = "punch";
    
    public void Attack(Animator animator)
    {
        Debug.Log("attacking with " + trigger); 
        animator.SetBool(trigger, true);
        Collider[] enemiesHit = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach (var enemy in enemiesHit)
        { 
            Debug.Log("hit" + enemy.name); 
            enemy.GetComponent<ZombieAI>().TakeDamage(damageAmount);

        }
        // Vector3 distanceToPlayer = player.position - transform.position;
        // if (!equipped && distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E) )
        // {
        //     PickUp();
        // }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
         Gizmos.DrawSphere(attackPoint.position, attackRange);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

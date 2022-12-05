using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zombie_Logic;

public class WeaponScript : MonoBehaviour
{
    //interpolated from youtube 
    
    public Transform attackPoint;
    public float attackRange = 3f;
    public LayerMask enemyLayers;
    public float damageAmount = 1f;
    public String trigger = "punch";
    public float attackCooldownSeconds;
    public float lastAttackTime;
    public AudioSource hitSound;
    
    public void Attack(Animator animator)
    {
        if (Time.time - lastAttackTime > attackCooldownSeconds || lastAttackTime == 0f)
        {
            Debug.Log("attacking with " + trigger); 
            animator.SetBool(trigger, true);
            Collider[] enemiesHit = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

            foreach (var enemy in enemiesHit)
            { 
                Debug.Log("hit" + enemy.name); 
                enemy.GetComponent<AbstractZombieAI>().TakeDamage(damageAmount);

            }

            lastAttackTime = Time.time; 
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
         Gizmos.DrawSphere(attackPoint.position, attackRange);
    }

    private void OnCollisionEnter()
    {
        hitSound.Play();
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

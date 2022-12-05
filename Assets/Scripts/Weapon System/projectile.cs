using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zombie_Logic;

public class Projectile : MonoBehaviour
{

    public float damage;
    private Rigidbody rb;

    private bool targetHit = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (!targetHit)
        {
            if (collision.gameObject.GetComponent<AbstractZombieAI>() != null)
            {
                collision.gameObject.GetComponent<AbstractZombieAI>().TakeDamage(damage);
            }
        }
    }
}

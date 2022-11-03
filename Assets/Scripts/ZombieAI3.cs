using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class ZombieAI3 : ZombieAIBase
{
    private float runSpeed = 10f;
    private float walkSpeed;
    private float zombieHealth = 20f;
    
    
    private new void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Bryce")//or tag
        {
            collision.gameObject.GetComponent<PlayerController>().PlayerHpSystem.TakeDamage(7f);
            isBryceDead = true;
        }
    }
}
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;
public class ZombieAI1 : ZombieAIBase
{
    
    private float runSpeed = 30f;
    private float walkSpeed;
    private float zombieHealth = 3f;
    
     private new void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Bryce")//or tag
        {
            collision.gameObject.GetComponent<PlayerController>().PlayerHpSystem.TakeDamage(6f);
            isBryceDead = true;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageDealt)
    {
        currentHealth -= damageDealt;

        if (currentHealth <= 0f)
        {
            Debug.Log("Player died.");
            animator.SetBool("isDead", true);
        }
    }

    public void EnergyDrink(float replenished)
    {

        if (currentHealth + replenished >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else currentHealth += replenished;

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

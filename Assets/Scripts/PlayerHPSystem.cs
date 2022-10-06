using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    
    
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
            Destroy(gameObject);
        }
    }

    public void EnergyDrink(float replenished)
    {
        if (currentHealth + replenished >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        currentHealth += replenished;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

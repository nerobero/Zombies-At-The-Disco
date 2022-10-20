using UnityEngine;

public class HPSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;

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
            // Destroy(gameObject);
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

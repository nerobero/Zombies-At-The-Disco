using UnityEngine;

public class HPSystem : MonoBehaviour
{
   public float maxHealth = 100f;
   public float currentHealth = 100f;

   public HealthBarScript healthbar;

   // Start is called before the first frame update
   void Start()
   {
       currentHealth = maxHealth;
       healthbar.setMaxHealth(currentHealth);
   }

   //when called, the object that calls the function takes damage
   public void TakeDamage(float damageDealt)
   {
       currentHealth -= damageDealt;
       healthbar.setHealth(currentHealth);

       if (currentHealth <= 0f)
       {
           Debug.Log("Player died.");
           // Destroy(gameObject);
       }
   }

   //drinks energy drink; solely for the player
   public void EnergyDrink(float replenished)
   {

       if (currentHealth + replenished >= maxHealth)
       {
           currentHealth = maxHealth;
       }
       else currentHealth += replenished;
       healthbar.setHealth(currentHealth);

   }
  
   // Update is called once per frame
   void Update()
   {
      
   }
}
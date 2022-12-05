using UnityEngine;

public class HPSystem : MonoBehaviour
{
   public float maxHealth = 100f;
   public float currentHealth = 100f;

   public HealthBarScript healthbar;

   public PlayerGameManager pgm;
   public AudioSource damageSound;
   public Animator animator;
   
   // Start is called before the first frame update
   void Start()
   {
       currentHealth = maxHealth;
       healthbar.setMaxHealth(currentHealth);
   }

   //when called, the object that calls the function takes damage
   public void TakeDamage(float damageDealt)
   {
       animator.SetTrigger("takeDamage");
       currentHealth -= damageDealt;
       healthbar.setHealth(currentHealth);
       damageSound.Play();

       if (currentHealth <= 0f)
       {
           //should disable player movement here before ending game round: 
           pgm.EndGameRound();
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
   
}

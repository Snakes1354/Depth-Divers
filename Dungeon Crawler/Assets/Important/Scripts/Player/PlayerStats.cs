using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

   public static PlayerStats Instance;
   // I used a static so that my playerstats can be accessed from other scripts.
   
   // VARIABLES
   public float maxHealth = 100f;
   public float currentHealth;
   public float MaxHealth => maxHealth;
   public float CurrentHealth => currentHealth;

   public HealthBar healthBar; // Lets you assign a healthbar in the inspector
   
   private void Start()
   {
       currentHealth = maxHealth; 
       healthBar.SetSliderMax(maxHealth);
       // At the start of the game the current health is set to the max health
   }
   private void Update()
   {
       if (currentHealth > maxHealth)
           currentHealth = maxHealth;
       if (currentHealth <= 0)
           Die();
        // Makes it so if current health reachs bellow 0 or 0 you die
   }
   public void TakeDamage(float amount)
   {
       currentHealth -= amount;
       healthBar.SetSlider(currentHealth);
       // This method is used to update the healthbar and is used to take damage

   }
   public void HealPlayer(float amount)
   {
       currentHealth += amount;
       healthBar.SetSlider(currentHealth);
       // This method is used to heal the player and update the health bar
   }
   private void Die()
   {
        UnityEngine.SceneManagement.SceneManager.LoadScene("End Menu"); // Goes to my End Menu scene
        Cursor.visible = true; // Sets my cursor visiblity to true
        Cursor.lockState = CursorLockMode.None; // This unlocks my cursor
   }

   private void Awake()
   {
        if(Instance == null)
        Instance = this;
        else
        Destroy(gameObject); // Destroys the gameobject
        // Makes it so that there can't be more than one playerstats in my game.
   }
}
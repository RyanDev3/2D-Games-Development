using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    private int currentHealth;
    [SerializeField] private Transform respawnPoint; 
    [SerializeField] private TMP_Text currentHealthText;

    public static PlayerHealth Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple PlayerHealth scripts found in the scene!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentHealth = maxHealth;

        if (currentHealthText == null)
        {
            Debug.LogError("PlayerHealth: No TMP_Text found in the scene!");
        }

        UpdateHealthUI();
    }



    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player took " + damageAmount + " damage. Current health: " + currentHealth);

        UpdateHealthUI();
            
            
        if (currentHealth <= 0)
        {
            Debug.Log("PlayerHealth: Calling Die() from TakeDamage()");
            Die();
        }
    }
    void UpdateHealthUI()
    {
        if (currentHealthText != null)
        {
            currentHealthText.text = "Health: " + currentHealth;
        }
    }
    
    
    public void Die()
    {
        Debug.Log("PlayerHealth: Player has died!");
        SceneManager.LoadScene("EndScreen");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("PlayerHealth: OnTriggerEnter2D with: " + other.gameObject.tag + ", other.name: " +
                  other.gameObject.name);
        if (other.gameObject.CompareTag("enemyBullet"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    private int currentHealth;

    [SerializeField] private Transform respawnPoint; // ✅ ADD THIS

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
        Debug.Log("Player health: " + currentHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player took " + damageAmount + " damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("PlayerHealth: Calling Die() from TakeDamage()");
            Die();
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

  /*  public void Respawn()
    {
        Debug.Log("Player is respawning...");
        transform.position = respawnPoint.position;
    }
  */
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
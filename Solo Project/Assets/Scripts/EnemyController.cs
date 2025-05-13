using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float minStopXPosition;
    [SerializeField] private float maxStopXPosition;
    private float stopXPosition;
    
    [SerializeField] private float speed;
    [SerializeField] private int maxHealth;
    private int currentHealth;

    private bool isPositioned;
    
    void Start()
    {
        currentHealth = maxHealth;
        
        stopXPosition = Random.Range(minStopXPosition + 0.0f, maxStopXPosition + 0.0f);
    }
    
    void Update()
    {
        if (!isPositioned) transform.Translate(-speed * Time.deltaTime, 0, 0);
        
        if (transform.position.x < stopXPosition)
        {
            isPositioned = true;
            transform.position = new Vector2(stopXPosition, transform.position.y);
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerBullet"))
        {
            Destroy(other.gameObject);
            
            currentHealth -= 1;
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
}

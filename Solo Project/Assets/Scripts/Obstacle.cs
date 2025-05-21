using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;

    public Transform player;
    public float obstacleSpeed;
    public float obstacleLifetime = 5f; 

    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        if (obstaclePrefab == null)
        {
            Debug.LogError("Obstacle Prefab is not assigned in the Inspector!");
            return;
        }
        if (player == null)
        {
            Debug.LogError("Player reference is missing! Is the player in the scene?");
            return;
        }
        if (obstaclePrefab == null || player == null)
        {
            Debug.LogError("Obstacle prefab or Player is not assigned!");
            return;
        }

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        GameObject spawnedObstacle = Instantiate(
            obstaclePrefab, 
            transform.position + new Vector3(randomX, randomY, 0), 
            transform.rotation
        );

        Destroy(spawnedObstacle, obstacleLifetime);

        // Set up movement
        Rigidbody2D rb = spawnedObstacle.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = (player.position - spawnedObstacle.transform.position).normalized;
            rb.linearVelocity = direction * obstacleSpeed;
        }
        
        ObstacleDamage damageScript = spawnedObstacle.AddComponent<ObstacleDamage>();
        damageScript.damageAmount = 1; // Or whatever damage you want
    }
}

public class ObstacleDamage : MonoBehaviour
{
    public int damageAmount = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Destroy(gameObject); // Destroy the obstacle after hitting
            }
        }
    }
}
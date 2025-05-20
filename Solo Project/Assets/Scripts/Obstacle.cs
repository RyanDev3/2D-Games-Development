using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;

    public Transform player; 
    public float obstacleSpeed;

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
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        if (obstacle != null && player != null)
        {
            GameObject spawnedObstacle = Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
            Rigidbody2D rb = spawnedObstacle.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 direction = (player.position - spawnedObstacle.transform.position).normalized;
                rb.linearVelocity = direction * obstacleSpeed;
            }
        }
        else
        {
            Debug.LogError("Obstacle or Player is not assigned in the Inspector.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(4);
            }
        }
    }
}
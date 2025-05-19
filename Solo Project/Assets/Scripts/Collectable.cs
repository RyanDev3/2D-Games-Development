using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float attractRadius = 3f;
    [SerializeField] private float moveSpeed = 5f;

    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= attractRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ClearAllEnemies();
            Destroy(gameObject);
        }
    }

    void ClearAllEnemies()
    {
        EnemyController[] enemies = FindObjectsOfType<EnemyController>();
        foreach (EnemyController enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }
}
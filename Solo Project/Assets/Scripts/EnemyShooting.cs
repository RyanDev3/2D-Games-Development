using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float fireRate = 2f;
    private float nextFireTime;
    private Transform playerTransform;

    void Start()
    {
        nextFireTime = Time.time;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player GameObject not found! Make sure the player is tagged as 'Player'.");
        }
    }

    void Update()
    {
        if (playerTransform != null && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 direction = (playerTransform.position - firePoint.position).normalized;
        rb.linearVelocity = direction * bulletSpeed;
        bullet.tag = "enemyBullet"; 
        Destroy(bullet, 3f);
    }
}
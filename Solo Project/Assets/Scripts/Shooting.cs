using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign this in the Unity Inspector
    public float bulletSpeed = 10f;
    public Transform firePoint; // The point from where bullets spawn

    private bool isShooting;
    private float shootCooldown = 0.15f; // Time between shots
    private float shootCooldownTimer;

    void Start()
    {
        isShooting = false;
        shootCooldownTimer = 0f;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Press Space to shoot
        {
            isShooting = true;
        }
        
        if (Input.GetKeyUp(KeyCode.Space)) // Stop shooting when Space is released
        {
            isShooting = false;
        }
         
        if (shootCooldownTimer > 0)
        {
            shootCooldownTimer -= Time.deltaTime;
        }
        
        if (shootCooldownTimer <= 0 && isShooting)
        {
            Shoot();
            shootCooldownTimer = shootCooldown; // Reset cooldown
        }
    }
   

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.right * bulletSpeed; // Shoots to the right
        Destroy(bullet, 3f);
    }
}
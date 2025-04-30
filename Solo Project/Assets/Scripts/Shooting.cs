using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign this in the Unity Inspector
    public float bulletSpeed = 10f;
    public Transform firePoint; // The point from where bullets spawn

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Press Space to shoot
        {
            Shoot();
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
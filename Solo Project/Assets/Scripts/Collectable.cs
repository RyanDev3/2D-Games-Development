using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed at which it moves towards the player

    private Transform player;
    private CollectableSpawner spawner;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player"); // Find player by tag
        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        spawner = FindObjectOfType<CollectableSpawner>(); // Find the spawner
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Hit player.");
            
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
                print("[DEBUG] ENEMIES R DOOMED TO DIE YEYE");
            }

            // Tell the spawner to respawn after 20 seconds
            spawner.RespawnCollectable();
            
            Destroy(gameObject);
        }
    }
}

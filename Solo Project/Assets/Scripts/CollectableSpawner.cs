using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private GameObject collectablePrefab;
    [SerializeField] private float spawnInterval = 15f; // Respawn time
    [SerializeField] private Vector2 minSpawnPos;
    [SerializeField] private Vector2 maxSpawnPos;

    private GameObject currentCollectable;

    void Start()
    {
        SpawnCollectable();
    }

    void SpawnCollectable()
    {
        if (currentCollectable == null) // Make sure there�s no active collectable
        {
            Vector2 spawnPosition = new Vector2(
                Random.Range(minSpawnPos.x, maxSpawnPos.x),
                Random.Range(minSpawnPos.y, maxSpawnPos.y)
            );

            currentCollectable = Instantiate(collectablePrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void RespawnCollectable()
    {
        Invoke(nameof(SpawnCollectable), spawnInterval); 
    }
}

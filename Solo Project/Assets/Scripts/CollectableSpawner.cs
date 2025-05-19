using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private GameObject collectablePrefab;
    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private Vector2 minSpawnPos;
    [SerializeField] private Vector2 maxSpawnPos;

    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnCollectable();
            timer = spawnInterval;
        }
    }

    void SpawnCollectable()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(minSpawnPos.x, maxSpawnPos.x),
            Random.Range(minSpawnPos.y, maxSpawnPos.y)
        );

        Instantiate(collectablePrefab, spawnPosition, Quaternion.identity);
    }
}
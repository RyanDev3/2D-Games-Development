using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    
    [SerializeField] private Transform Player;
    
    [SerializeField] private float initialSpawnTime = 2f;
    private float spawnTime;
    private float spawnTimeTimer;
    [SerializeField] private float difficultySpeed = 1f;
    
    private float timePassed;

    void Start()
    {
        spawnTime = initialSpawnTime;
        timePassed = 0f;
        
        InvokeRepeating("IncreaseDifficulty", 1, 1);
    }
    
    void Update()
    {
        spawnTimeTimer +=  Time.deltaTime;
        if (spawnTimeTimer >= spawnTime)
        {
            SpawnEnemy();
            spawnTimeTimer = 0f;
        }
    }
    
    void SpawnEnemy()
    {
        float randomY = Random.Range(-4f, 4f);
        Vector2 spawnPosition = new Vector2(8, randomY);
        
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        //enemy.GetComponent<EnemyController>().SetTarget(Player);
        
        spawnTime -= difficultySpeed * Time.deltaTime;
    }

    void IncreaseDifficulty()
    {
        spawnTime /= 1 + (0.01f * difficultySpeed);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float initialSpawnTime = 2f;
    private float spawnTime;
    private float spawnTimeTimer;
    [SerializeField] private float difficultySpeed = 1f;
    
    public float currentTime { get; private set; }
    [SerializeField] private float level2Threshold = 5f;
    [SerializeField] private float gameEndThreshold = 10f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    void Start()
    {
        spawnTime = initialSpawnTime;
        spawnTimeTimer = 0f;
        currentTime = 0f;
        
        InvokeRepeating("IncreaseDifficulty", 1, 1);
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        
        if (currentTime > level2Threshold && currentTime <= gameEndThreshold && SceneManager.GetActiveScene().name != "Level2")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (currentTime > gameEndThreshold)
        {
            SceneManager.LoadScene("GameEnd");
        }
        
        spawnTimeTimer += Time.deltaTime;
        if (spawnTimeTimer >= spawnTime)
        {
            SpawnEnemy();
            spawnTimeTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || player == null) return;

        float randomY = Random.Range(-4f, 4f);
        Vector2 spawnPosition = new Vector2(8, randomY);
        
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    void IncreaseDifficulty()
    {
        spawnTime = Mathf.Max(0.1f, spawnTime / (1 + (0.01f * difficultySpeed)));
    }
    
    public void ResetGame()
    {
        currentTime = 0f;
        spawnTime = initialSpawnTime;
    }
}
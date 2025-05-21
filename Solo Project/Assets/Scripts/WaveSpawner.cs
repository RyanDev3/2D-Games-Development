using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeBetweenWaves = 5f;
    
    [Header("Level Settings")]
    [SerializeField] private int level1Waves = 3;
    [SerializeField] private int level1EnemiesPerWave = 3;
    [SerializeField] private int level2Waves = 5;
    [SerializeField] private int level2EnemiesPerWave = 5;

    private int currentLevel = 1;
    private int currentWave = 0;
    private bool isSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            if (!isSpawning && currentWave < GetTotalWaves())
            {
                isSpawning = true;
                currentWave++;
                yield return StartCoroutine(SpawnWave(GetEnemiesPerWave()));
                isSpawning = false;
                
                if (currentWave >= GetTotalWaves())
                {
                    // All waves completed for this level
                    yield break;
                }
                
                yield return new WaitForSeconds(timeBetweenWaves);
            }
            yield return null;
        }
    }

    IEnumerator SpawnWave(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

    public void SetLevel(int level)
    {
        currentLevel = level;
        currentWave = 0;
        isSpawning = false;
        StopAllCoroutines();
        StartCoroutine(SpawnWaves());
    }

    private int GetTotalWaves()
    {
        return currentLevel == 2 ? level2Waves : level1Waves;
    }

    private int GetEnemiesPerWave()
    {
        return currentLevel == 2 ? level2EnemiesPerWave : level1EnemiesPerWave;
    }
}
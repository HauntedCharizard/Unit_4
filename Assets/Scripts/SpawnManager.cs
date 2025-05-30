using System.Numerics;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public int enemyCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        SpawnEnemyWave(3);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0) { SpawnEnemyWave(1); }
    }

    private UnityEngine.Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        UnityEngine.Vector3 randomPos = new UnityEngine.Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }


    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}

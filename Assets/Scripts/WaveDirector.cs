using System;
using UnityEngine;

public class WaveDirector : MonoBehaviour
{
    public event Action<int> OnRemainingEnemiesChanged;
    public event Action OnWaveClear;
    public event Action<int, int> OnWaveBegin;
    public event Action<float> OnRestTimeChanged;
    
    [SerializeField] Wave[] waves;
    [SerializeField] EnemySpawner spawner;
    [SerializeField] EnemyRegistry registry;
    
    int currentWaveIndex;
    int totalSpawnCount;
    int lastRemainingCount = -1;
    
    float spawnTimer;
    float restTimer;

    void Start() {
        if (waves.Length > 0)
            BeginWave(0);
    }

    void Update() {
        // 所有波次结束
        if (currentWaveIndex >= waves.Length) 
            return;

        // 波间休整
        if (restTimer > 0f) {
            restTimer -= Time.deltaTime;
            OnRestTimeChanged?.Invoke(restTimer);

            // 休整结束
            if (restTimer <= 0f)
                BeginWave(currentWaveIndex + 1);
            
            return;
        }
        
        Wave wave = waves[currentWaveIndex];

        NotifyRemainingEnemies();

        // 本波已经刷够数量，等待敌人全部死亡
        if (totalSpawnCount >= wave.TotalSpawn) {
            if (registry.AliveCount == 0)
                BeginRest();
            
            return;
        }
        
        spawnTimer -= Time.deltaTime;

        // 等待刷怪间隔，或等待场上腾出位置
        if (spawnTimer > 0f || registry.AliveCount >= wave.AliveCount) 
            return;
        
        spawner.SpawnZombie();
        totalSpawnCount++;
        spawnTimer = wave.SpawnInterval;
    }

    void BeginRest() {
        // 还有下一波才进入休整
        if (currentWaveIndex >= waves.Length - 1)
            return;
        
        restTimer = waves[currentWaveIndex].restDuration;
        OnRestTimeChanged?.Invoke(restTimer);
        OnWaveClear?.Invoke();
    }

    void BeginWave(int index) {
        currentWaveIndex = index;
        totalSpawnCount = 0;
        spawnTimer = 0f;

        OnWaveBegin?.Invoke(currentWaveIndex, waves.Length);
        NotifyRemainingEnemies();
    }

    void NotifyRemainingEnemies() {
        int remaining = waves[currentWaveIndex].TotalSpawn
                        - totalSpawnCount
                        + registry.AliveCount;

        if (remaining == lastRemainingCount) 
            return;

        lastRemainingCount = remaining;
        OnRemainingEnemiesChanged?.Invoke(remaining);
    }
}

[Serializable]
public struct Wave
{
    public int TotalSpawn;
    public float SpawnInterval;
    public int AliveCount;
    public float restDuration;
}
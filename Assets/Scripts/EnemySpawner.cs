using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float timeInterval;
    [SerializeField] float maxCount;

    Transform player;
    float spawnTimer;
    float spawnCounter;
    
    public EnemyController Spawn(GameObject prefab, Transform spawnPoint) {
        var obj = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        obj.GetComponent<EnemyPerception>().SetTarget(player);
        return obj.GetComponent<EnemyController>();
    }

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f) {
            spawnTimer = timeInterval;
            
            if (spawnCounter >= maxCount) return;
            
            Spawn(enemyPrefab, spawnPoint);
            spawnCounter++;
        }
    }
}
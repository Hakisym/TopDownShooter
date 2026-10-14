using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyRegistry registry;
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] Transform spawnPoint;

    Transform player;
    
    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    public EnemyController Spawn(GameObject prefab, Transform spawnPoint) {
        var obj = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        obj.GetComponent<EnemyPerception>().SetTarget(player);
        obj.GetComponent<EnemyLifecycle>().Initialize(registry);
        return obj.GetComponent<EnemyController>();
    }

    public EnemyController SpawnZombie() {
        return Spawn(zombiePrefab, spawnPoint);
    }
}
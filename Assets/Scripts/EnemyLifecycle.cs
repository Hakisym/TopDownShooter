using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLifecycle : MonoBehaviour
{
    [SerializeField] EnemyController enemyController;
    [SerializeField] EnemyHealth enemyHealth;
    
    EnemyRegistry registry;
    
    void Start() {
        enemyHealth.OnEnemyDied += HandlePlayerDeath;
    }

    public void Initialize(EnemyRegistry registry) {
        this.registry = registry;
        registry.RegisterEnemy(enemyController);
    }

    void HandlePlayerDeath() {
        GetComponent<Collider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        
        foreach (var script in GetComponents<MonoBehaviour>()) {
            if (script == this) continue;
            script.enabled = false;
        }

        registry.UnregisterEnemy(enemyController);

        StartCoroutine(DeathCoroutine());
    }

    IEnumerator DeathCoroutine() {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
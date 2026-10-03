using System;
using System.Collections;
using UnityEngine;

public class EnemyLifecycle : MonoBehaviour
{
    [SerializeField] EnemyHealth enemyHealth;
    
    void Start() {
        enemyHealth.OnEnemyDied += HandlePlayerDeath;
    }

    void HandlePlayerDeath() {
        GetComponent<Collider>().enabled = false;
        
        foreach (var script in GetComponents<MonoBehaviour>()) {
            if (script == this) continue;
            script.enabled = false;
        }

        StartCoroutine(DeathCoroutine());
    }

    IEnumerator DeathCoroutine() {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
using System;
using UnityEngine;

public class PlayerVisualEffect : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] GameObject deathEffect;
    [SerializeField] Transform effectSpawnPoint;

    void Start() {
        playerHealth.OnPlayerDied += SpawnDeathParticles;
    }

    void SpawnDeathParticles() {
        Instantiate(deathEffect, effectSpawnPoint.position, Quaternion.identity);
    }
}
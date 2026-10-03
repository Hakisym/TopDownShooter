using System;
using UnityEngine;

public class PlayerVisualEffect : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] GameObject deathEffect;

    void Start() {
        playerHealth.OnPlayerDied += SpawnDeathParticles;
    }

    void SpawnDeathParticles() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
}
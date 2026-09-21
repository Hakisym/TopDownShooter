using System;
using UnityEngine;

public class PlayerVisualEffect : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Transform deathEffectSocket;
    [SerializeField] GameObject deathEffect;

    void Start() {
        playerHealth.OnPlayerDied += SpawnDeathParticles;
    }

    void SpawnDeathParticles() {
        Instantiate(deathEffect, deathEffectSocket);
    }
}
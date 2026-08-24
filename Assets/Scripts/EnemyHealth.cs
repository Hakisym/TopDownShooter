using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth;

    float currentHealth;

    void Awake() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage) {
        currentHealth -= damage;

        if (currentHealth <= 0)
            Die();
    }

    void Die() {
        Debug.Log("dead");
    }
}
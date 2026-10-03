using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth;
    public event Action OnEnemyDied;

    public float CurrentHealth { get; private set; }
    public float MaxHealth => maxHealth;
    
    public bool IsDead { get; private set; }

    void Awake() {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float damage) {
        CurrentHealth = Mathf.Max(0f, CurrentHealth - damage);

        if (CurrentHealth <= 0)
            Die();
    }

    void Die() {
        IsDead = true;
        OnEnemyDied?.Invoke();
    }
}
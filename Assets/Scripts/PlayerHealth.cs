using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IDamageable
{
    public event Action<float, float> OnHealthChange;
    public event Action OnPlayerDied;
    
    [SerializeField] float maxHealth = 100f;

    public float CurrentHealth { get; private set; }
    public float MaxHealth => maxHealth;
    
    public bool IsDead { get; private set; }

    void Awake() {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float damage) {
        CurrentHealth = Mathf.Max(0f, CurrentHealth - damage);

        OnHealthChange?.Invoke(CurrentHealth, maxHealth);

        if (CurrentHealth <= 0)
            Die();
    }

    void Die() {
        IsDead = true;
        OnPlayerDied?.Invoke();
    }
}
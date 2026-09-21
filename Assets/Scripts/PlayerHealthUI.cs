using System;
using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] TextMeshProUGUI healthText;

    void Start() {
        playerHealth.OnHealthChange += UpdateHealthText;
        UpdateHealthText(playerHealth.CurrentHealth, playerHealth.MaxHealth);
    }

    void UpdateHealthText(float cur, float max) {
        healthText.text = cur.ToString("F0");
    }
}
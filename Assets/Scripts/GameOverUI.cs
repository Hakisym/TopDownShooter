using System;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Transform container;
    [SerializeField] PlayerHealth playerHealth;

    void Awake() {
        container.gameObject.SetActive(false);
    }

    void Start() {
        playerHealth.OnPlayerDied += PlayerHealth_OnPlayerDied; 
    }

    void PlayerHealth_OnPlayerDied() {
        container.gameObject.SetActive(true);
    }
}
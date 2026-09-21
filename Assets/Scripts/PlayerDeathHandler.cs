using System;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Transform playerVisual;
    [SerializeField] Transform weaponSocket;
    
    void Start() {
        playerHealth.OnPlayerDied += HandlePlayerDeath;
    }

    void HandlePlayerDeath() {
        GetComponent<CharacterController>().enabled = false;
        
        foreach (var script in GetComponents<MonoBehaviour>()) {
            if (script == this) continue;
            script.enabled = false;
        }

        playerVisual.gameObject.SetActive(false);
        weaponSocket.gameObject.SetActive(false);
    }
}
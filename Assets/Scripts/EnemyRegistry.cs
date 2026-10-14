using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRegistry : MonoBehaviour
{
    [SerializeField] WaveDirector waveDirector;
    
    List<EnemyController> enemies;
    
    public int AliveCount => enemies.Count;
    
    void Awake() {
        enemies = new List<EnemyController>();
    }

    void Start() {
        waveDirector.OnWaveClear += WaveDirector_OnWaveClear;
    }

    void WaveDirector_OnWaveClear() {
        enemies.Clear();
    }

    public void RegisterEnemy(EnemyController enemy) {
        if (enemies.Contains(enemy)) return;
        
        enemies.Add(enemy);
    }

    public void UnregisterEnemy(EnemyController enemy) {
        if (!enemies.Contains(enemy)) return;
        
        enemies.Remove(enemy);
    }
}
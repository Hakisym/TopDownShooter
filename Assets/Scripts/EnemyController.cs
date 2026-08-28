using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyPerception perception;
    [SerializeField] EnemyBrain brain;
    [SerializeField] EnemyBehaviour behaviour;
    [SerializeField] EnemyAnimator animator;
    
    EnemyRuntimeData data;

    void Awake() {
        data = new EnemyRuntimeData(transform);
    }

    void Update() {
        data = perception.Tick(data);
        data = brain.Tick(data);
        
        behaviour.Tick(data);
        animator.Tick(data);
    }
}
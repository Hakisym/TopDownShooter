using System;
using UnityEngine;

public class EnemyPerception : MonoBehaviour
{
    [SerializeField] Transform debugTarget;
    Transform target;
    PlayerHealth targetHealth;

    void Awake() {
        SetTarget(debugTarget);
    }

    public void SetTarget(Transform newTarget) {
        target = newTarget;

        targetHealth = target
            ? target.GetComponent<PlayerHealth>()
            : null;
    }

    public void Tick(EnemyRuntimeData data) {
        if (!target || 
            targetHealth == null || 
            targetHealth.IsDead) {
            ClearTarget(data);
            return;
        }

        var offset =
            target.position - data.EnemyTransform.position;
        
        offset.y = 0f;
        
        var direction = offset.sqrMagnitude > 0.001f 
            ? offset.normalized
            : Vector3.zero;
        
        data.PerceptionData.CurrentTarget = target;
        data.PerceptionData.TargetPosition = target.position;
        data.PerceptionData.DistanceToTarget = offset.magnitude;
        data.PerceptionData.DirectionToTarget = direction;
    }

    void ClearTarget(EnemyRuntimeData data) {
        target = null;
        targetHealth = null;
        
        data.PerceptionData.CurrentTarget = null;
        data.PerceptionData.TargetPosition = Vector3.zero;
        data.PerceptionData.DistanceToTarget = float.PositiveInfinity;
        data.PerceptionData.DirectionToTarget = Vector3.zero;
    }
}
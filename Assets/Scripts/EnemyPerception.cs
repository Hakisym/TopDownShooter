using System;
using UnityEngine;

public class EnemyPerception : MonoBehaviour
{
    [SerializeField] Transform target;

    public void SetTarget(Transform newTarget) {
        target = newTarget;
    }

    public void Tick(EnemyRuntimeData data) {
        if (!target) {
            ClearPerceptionData(data);
            return;
        }

        var offset = target.position - data.EnemyTransform.position;
        offset.y = 0f;
        var direction = offset.sqrMagnitude > 0.001f 
            ? offset.normalized
            : Vector3.zero;
        
        data.PerceptionData.CurrentTarget = target;
        data.PerceptionData.TargetPosition = target.position;
        data.PerceptionData.DistanceToTarget = offset.magnitude;
        data.PerceptionData.DirectionToTarget = direction;
    }

    void ClearPerceptionData(EnemyRuntimeData data) {
        data.PerceptionData.CurrentTarget = null;
        data.PerceptionData.TargetPosition = Vector3.zero;
        data.PerceptionData.DistanceToTarget = float.PositiveInfinity;
        data.PerceptionData.DirectionToTarget = Vector3.zero;
    }
}
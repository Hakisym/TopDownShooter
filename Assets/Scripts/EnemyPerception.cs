using System;
using UnityEngine;

public class EnemyPerception : MonoBehaviour
{
    [SerializeField] Transform target;

    public void SetTarget(Transform newTarget) {
        target = newTarget;
    }

    public EnemyRuntimeData Tick(EnemyRuntimeData data) {
        if (!target)
            return ClearPerception(data);

        var offset = target.position - data.EnemyTransform.position;
        var direction = offset.sqrMagnitude > 0.001f 
            ? offset 
            : Vector3.zero;
        direction.y = 0f;
        
        data.DecisionData.CurrentTarget = target;
        data.DecisionData.TargetPosition = target.position;
        data.DecisionData.DistanceToTarget = offset.magnitude;
        data.DecisionData.DirectionToTarget = direction.normalized;
        
        return data;
    }

    EnemyRuntimeData ClearPerception(EnemyRuntimeData data) {
        data.DecisionData.CurrentTarget = null;
        data.DecisionData.TargetPosition = Vector3.zero;
        data.DecisionData.DistanceToTarget = float.PositiveInfinity;
        data.DecisionData.DirectionToTarget = Vector3.zero;
        
        return data;
    }
}
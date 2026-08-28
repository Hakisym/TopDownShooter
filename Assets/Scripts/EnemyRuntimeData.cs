using UnityEngine;

public struct EnemyRuntimeData
{
    public readonly Transform EnemyTransform;
    public EnemyDecisionData DecisionData;
    public EnemyStateType StateType;

    public EnemyRuntimeData(Transform enemyTransform) {
        EnemyTransform = enemyTransform;
        DecisionData = new EnemyDecisionData();
        StateType = EnemyStateType.Idle;
    }
}

public struct EnemyDecisionData
{
    public Transform CurrentTarget;
    public bool HasTarget => CurrentTarget != null;
    public Vector3 TargetPosition;
    public float DistanceToTarget;
    public Vector3 DirectionToTarget;
}

public enum EnemyStateType{
    Idle,
    Chase,
    Attack,
}
using System;
using UnityEngine;

[Serializable]
public class EnemyRuntimeData
{
    public readonly Transform EnemyTransform;
    public EnemyPerceptionData PerceptionData;
    public EnemyIntentData IntentData;
    public EnemyRequestData RequestData;
    public EnemyState State;
    public EnemyActionData ActionData;

    public EnemyRuntimeData(Transform enemyTransform) {
        EnemyTransform = enemyTransform;
    }
}

[Serializable]
public struct EnemyPerceptionData
{
    public Transform CurrentTarget;
    public bool HasTarget => CurrentTarget != null;
    
    public Vector3 TargetPosition;
    public float DistanceToTarget;
    public Vector3 DirectionToTarget;
}

[Serializable]
public struct EnemyIntentData
{
    public bool HasIntent => WantToAttack || WantToChase;
    public bool WantToAttack;
    public bool WantToChase;
}

[Serializable]
public struct EnemyRequestData
{
    public bool RequestChase;
    public bool RequestAttack;
}

[Serializable]
public struct EnemyActionData
{
    public EnemyAction CurrentAction;
    public AttackPhase AttackPhase;
}

public enum EnemyState{
    Idle,
    Chase,
    Attack,
}

public enum EnemyAction
{
    None,
    Attack
}

public enum AttackPhase
{
    None,
    Startup,
    Active,
    Recovery
}
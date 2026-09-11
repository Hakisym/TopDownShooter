using System;
using UnityEngine;

[Serializable]
public class EnemyRuntimeData
{
    public readonly Transform EnemyTransform;
    
    // Refreshed or generated during the current frame
    public EnemyPerceptionData PerceptionData;
    public EnemyIntentData IntentData;
    public EnemyDecisionResultData DecisionResult;
    public EnemyCommandData CommandData;
    public EnemyResultData ResultData;
    
    // Long-lived facts owned by their domain systems
    public EnemyActionData ActionData;
    public EnemyMovementData MovementData;

    public EnemyRuntimeData(Transform enemyTransform) {
        EnemyTransform = enemyTransform;
    }

    public void CleanFrame() {
        IntentData = default;
        DecisionResult = default;
        CommandData = default;
        ResultData = default;
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
    public EnemyBehaviourType DesiredBehaviour;
}

[Serializable]
public struct EnemyDecisionResultData
{
    public EnemyBehaviourType ApprovedBehaviour;
}

[Serializable]
public struct EnemyCommandData
{
    public bool BeginAttack;
    public Vector3 MoveDirection;
    public Vector3 FaceDirection;
}

[Serializable]
public struct EnemyActionData
{
    public EnemyAction CurrentAction;
    public AttackPhase AttackPhase;

    public bool CanRotate;
}

[Serializable]
public struct EnemyMovementData
{
    public bool IsMoving;
    public bool IsRotating;
}

[Serializable]
public struct EnemyResultData
{
    public bool EnemyAttackFinished;
}

public enum EnemyBehaviourType
{
    None,
    Chase,
    TurnToTarget,
    Attack
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
using UnityEngine;

public class EnemyExecution
{
    public void Tick(EnemyRuntimeData data) {
        data.CommandData.FaceDirection = data.PerceptionData.DirectionToTarget;
        
        switch (data.DecisionResult.ApprovedBehaviour) {
            case EnemyBehaviourType.Attack:
                data.CommandData.BeginAttack = true;
                break;
            case EnemyBehaviourType.Chase:
                data.CommandData.ShouldMove = true;
                data.CommandData.MoveDestination = data.PerceptionData.TargetPosition;
                break;
            case EnemyBehaviourType.TurnToTarget:
                data.CommandData.ShouldRotate = true;
                break;
        }
    }
}
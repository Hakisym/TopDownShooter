using UnityEngine;

public class EnemyExecution
{
    public void Tick(EnemyRuntimeData data) {
        switch (data.DecisionResult.ApprovedBehaviour) {
            case EnemyBehaviourType.Attack:
                data.CommandData.BeginAttack = true;
                break;
            case EnemyBehaviourType.Chase:
                data.CommandData.BeginMove = true;
                break;
            case EnemyBehaviourType.TurnToTarget:
                data.CommandData.BeginRotate = true;
                break;
        }
    }
}
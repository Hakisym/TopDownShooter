public class EnemyExecution
{
    public void Tick(EnemyRuntimeData data) {
        switch (data.DecisionResult.ApprovedBehaviour) {
            case EnemyBehaviourType.Attack:
                data.CommandData.BeginAttack = true;
                break;
            case EnemyBehaviourType.Chase:
                data.CommandData.MoveDirection = data.PerceptionData.DirectionToTarget;
                break;
        }
    }
}
public class EnemyExecution
{
    public void Tick(EnemyRuntimeData data) {
        var direction = data.PerceptionData.DirectionToTarget;
        
        switch (data.DecisionResult.ApprovedBehaviour) {
            case EnemyBehaviourType.Attack:
                data.CommandData.BeginAttack = true;
                break;
            case EnemyBehaviourType.Chase:
                data.CommandData.MoveDirection = direction;
                data.CommandData.FaceDirection = direction;
                break;
            case EnemyBehaviourType.TurnToTarget:
                data.CommandData.FaceDirection = direction;
                break;
        }
    }
}
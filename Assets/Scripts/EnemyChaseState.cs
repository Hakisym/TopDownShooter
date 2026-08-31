using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    EnemyMovement movement;
    public EnemyChaseState(EnemyMovement movement) {
        this.movement = movement;
    }

    public override void Enter(EnemyRuntimeData data) {
        
    }

    public override void Tick(EnemyRuntimeData data) {
        var direction = data.PerceptionData.DirectionToTarget;

        movement.Rotate(direction);
        movement.Move(direction);
    }

    public override void Exit(EnemyRuntimeData data) { }
}
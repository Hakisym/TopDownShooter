using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    EnemyMovement movement;
    public EnemyChaseState(EnemyMovement movement) {
        this.movement = movement;
    }

    public override void Enter() {
        
    }

    public override void Tick(EnemyRuntimeData data) {
        var direction = data.DecisionData.DirectionToTarget;

        movement.Rotate(direction);
        movement.Move(direction);
    }

    public override void Exit() { }
}
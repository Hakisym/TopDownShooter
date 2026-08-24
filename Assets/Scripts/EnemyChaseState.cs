using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public EnemyChaseState(EnemyController enemy) : base(enemy) {
    }

    public override void Enter() {
        enemy.Animator.PlayAnimation(EnemyAnimator.WalkHash);
    }

    public override void Tick() {
        var direction = enemy.Target.TargetPosition - enemy.transform.position;
        direction.y = 0f;

        enemy.Movement.Rotate(direction.normalized);
        enemy.Movement.Move(direction.normalized);
    }

    public override void Exit() {
        
    }
}
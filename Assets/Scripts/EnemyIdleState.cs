public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyController enemy) : base(enemy) {
    }

    public override void Enter() {
        enemy.Animator.PlayAnimation(EnemyAnimator.IdleHash);
    }

    public override void Tick() {
    }

    public override void Exit() {
    }
}
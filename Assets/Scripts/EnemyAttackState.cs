public class EnemyAttackState : EnemyBaseState
{
    EnemyAttack attack;
    public EnemyAttackState(EnemyAttack attack) {
        this.attack = attack;
    }

    public override void Enter(EnemyRuntimeData data) {
        attack.Begin(data);
    }

    public override void Tick(EnemyRuntimeData data) {
        attack.Tick(data);
    }
    
    public override void Exit(EnemyRuntimeData data) {
        attack.Finish(data);
    }
}
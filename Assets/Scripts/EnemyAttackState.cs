public class EnemyAttackState : EnemyBaseState
{
    EnemyAttack attack;
    public EnemyAttackState(EnemyAttack attack) {
        this.attack = attack;
    }

    public override void Enter() {
        
    }

    public override void Tick(EnemyRuntimeData data) {
        attack.TryAttack();
    }
    
    public override void Exit() {
        
    }
}
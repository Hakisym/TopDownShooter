public abstract class EnemyBaseState : IEnemyState
{
    protected EnemyController enemy;

    protected EnemyBaseState(EnemyController enemy) {
        this.enemy = enemy;
    }

    public abstract void Enter();
    public abstract void Tick();
    public abstract void Exit();
}
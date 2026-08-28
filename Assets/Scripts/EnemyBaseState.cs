public abstract class EnemyBaseState : IEnemyState
{
    public abstract void Enter();
    public abstract void Tick(EnemyRuntimeData data);
    public abstract void Exit();
}
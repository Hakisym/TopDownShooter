public abstract class EnemyBaseState : IEnemyState
{
    public abstract void Enter(EnemyRuntimeData data);
    public abstract void Tick(EnemyRuntimeData data);
    public abstract void Exit(EnemyRuntimeData data);
}
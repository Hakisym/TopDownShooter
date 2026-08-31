public interface IEnemyState
{
    void Enter(EnemyRuntimeData data);
    void Exit(EnemyRuntimeData data);
    void Tick(EnemyRuntimeData data);
}
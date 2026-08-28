public interface IEnemyState
{
    void Enter();
    void Exit();
    void Tick(EnemyRuntimeData data);
}
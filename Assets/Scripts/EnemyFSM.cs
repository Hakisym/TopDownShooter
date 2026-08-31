public class EnemyFSM
{
    public IEnemyState CurrentState { get; private set; }

    public void ChangeState(IEnemyState newState, EnemyRuntimeData data) {
        CurrentState?.Exit(data);

        CurrentState = newState;
        
        CurrentState.Enter(data);
    }

    public void Tick(EnemyRuntimeData data) {
        CurrentState?.Tick(data);
    }
}
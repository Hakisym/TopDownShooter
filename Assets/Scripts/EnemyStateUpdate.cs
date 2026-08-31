using UnityEngine;

public class EnemyStateUpdate : MonoBehaviour
{
    public void Tick(EnemyRuntimeData data) {
        if (data.ActionData.CurrentAction == EnemyAction.None && data.State == EnemyState.Attack) {
            data.State = EnemyState.Idle;
        }
    }
}
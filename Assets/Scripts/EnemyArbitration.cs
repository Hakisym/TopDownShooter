using UnityEngine;

public class EnemyArbitration : MonoBehaviour
{
    public void Tick(EnemyRuntimeData data) {
        if (data.RequestData.RequestAttack && !CanAttack(data)) {
            data.RequestData.RequestAttack = false;
        }

        if (data.RequestData.RequestChase && !CanChase(data)) {
            data.RequestData.RequestChase = false;
        }
    }

    bool CanChase(EnemyRuntimeData data) {
        if (data.State == EnemyState.Attack)
            return false;

        return true;
    }

    bool CanAttack(EnemyRuntimeData data) {
        if (data.State == EnemyState.Chase)
            return true;

        return true;
    }
}
using UnityEngine;

public class EnemyRequest : MonoBehaviour
{
    public void Tick(EnemyRuntimeData data) {
        if (data.State != EnemyState.Attack && data.IntentData.WantToAttack) {
            data.RequestData.RequestAttack = true;
        }

        if (data.State != EnemyState.Chase && data.IntentData.WantToChase) {
            data.RequestData.RequestChase = true;
        }
    }
}
using UnityEngine;

public class EnemyIntention : MonoBehaviour
{
    [SerializeField] EnemyDecisionData decisionData;

    public void Tick(EnemyRuntimeData data) {
        UpdateIntent(data);
    }

    void UpdateIntent(EnemyRuntimeData data) {
        if (!data.PerceptionData.CurrentTarget)
            return;
        
        var distance = data.PerceptionData.DistanceToTarget;

        if (distance <= decisionData.attackRange)
            data.IntentData.WantToAttack = true;
        else
            data.IntentData.WantToChase = true;
    }
}
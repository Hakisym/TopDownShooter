public class EnemyIntention
{
    EnemyDecisionData decisionData;

    public EnemyIntention(EnemyDecisionData decisionData) {
        this.decisionData = decisionData;
    }

    public void Tick(EnemyRuntimeData data) {
        if (!data.PerceptionData.CurrentTarget) {
            data.IntentData.DesiredBehaviour = EnemyBehaviourType.None;
            return;
        }
        
        var distance = data.PerceptionData.DistanceToTarget;

        if (distance <= decisionData.attackRange)
            data.IntentData.DesiredBehaviour = EnemyBehaviourType.Attack;
        else
            data.IntentData.DesiredBehaviour = EnemyBehaviourType.Chase;
    }
}
public class EnemyArbitration
{
    public void Tick(EnemyRuntimeData data) {
        var desired = data.IntentData.DesiredBehaviour;
        
        if (desired == EnemyBehaviourType.None) {
            data.DecisionResult.ApprovedBehaviour = 
                EnemyBehaviourType.None;
            return;
        }

        if (data.ActionData.CurrentAction != EnemyAction.None) {
            data.DecisionResult.ApprovedBehaviour =
                EnemyBehaviourType.None;
            return;
        }

        data.DecisionResult.ApprovedBehaviour = desired;
    }
}
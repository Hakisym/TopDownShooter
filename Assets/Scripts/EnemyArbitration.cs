public class EnemyArbitration
{
    public void Tick(EnemyRuntimeData data) {
        var desired = data.IntentData.DesiredBehaviour;
        
        if (desired == EnemyBehaviourType.None) {
            data.DecisionResult.ApprovedBehaviour = 
                EnemyBehaviourType.None;
            return;
        }

        // If enemy is attacking, disapprove chase and attack intentions
        if (data.ActionData.CurrentAction == EnemyAction.Attack) {
            data.DecisionResult.ApprovedBehaviour =
                EnemyBehaviourType.None;
            return;
        }

        data.DecisionResult.ApprovedBehaviour = desired;
    }
}
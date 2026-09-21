using UnityEngine;

public class EnemyIntention
{
    EnemyData enemyData;

    public EnemyIntention(EnemyData enemyData) {
        this.enemyData = enemyData;
    }

    public void Tick(EnemyRuntimeData data) {
        if (!data.PerceptionData.CurrentTarget) {
            data.IntentData.DesiredBehaviour = EnemyBehaviourType.None;
            return;
        }

        var inAttackRange =
            data.PerceptionData.DistanceToTarget <= enemyData.decision.enterAttackRange;
        
        var angleToTarget = Vector3.Angle(
            data.EnemyTransform.forward,
            data.PerceptionData.DirectionToTarget
        );
        
        var facingTarget =
            angleToTarget <= enemyData.decision.attackFacingAngle;

        // Enemy wants to keep chasing the target until in attack range
        data.IntentData.DesiredBehaviour = inAttackRange && facingTarget
            ? EnemyBehaviourType.Attack 
            : EnemyBehaviourType.Chase;

        if (!inAttackRange) {
            data.IntentData.DesiredBehaviour = EnemyBehaviourType.Chase;
            return;
        }

        if (!facingTarget) {
            data.IntentData.DesiredBehaviour = EnemyBehaviourType.TurnToTarget;
            return;
        }

        data.IntentData.DesiredBehaviour = EnemyBehaviourType.Attack;
    }
}
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [Header("Combat Decision")] 
    [SerializeField] float enterAttackRange = 1.5f;
    [SerializeField] float exitAttackRange = 1.8f;

    public EnemyRuntimeData Tick(EnemyRuntimeData data) {
        var desiredState = DecideState(data.DecisionData, data.StateType);
        
        data.StateType = desiredState;
        
        return data;
    }

    EnemyStateType DecideState(EnemyDecisionData decisionData, EnemyStateType currentStateType) {
        if (!decisionData.CurrentTarget)
            return EnemyStateType.Idle;
        
        var distance = decisionData.DistanceToTarget;

        // 已经开始攻击后，目标要退得更远才退出攻击，
        // 避免在攻击距离边缘反复横跳。
        if (currentStateType == EnemyStateType.Attack) {
            if (distance <= exitAttackRange)
                return EnemyStateType.Attack;
        }
        else {
            if (distance <= enterAttackRange)
                return EnemyStateType.Attack;
        }
        
        return EnemyStateType.Chase;
    }
}
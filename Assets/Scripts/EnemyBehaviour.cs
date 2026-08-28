using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] EnemyMovement movement;
    [SerializeField] EnemyAttack attack;
    
    EnemyFSM fsm;

    EnemyChaseState chaseState;
    EnemyAttackState attackState;
    EnemyIdleState idleState;
    
    void Awake() {
        
        fsm = new EnemyFSM();

        idleState = new EnemyIdleState();
        chaseState = new EnemyChaseState(movement);
        attackState = new EnemyAttackState(attack);
    }

    public void Tick(EnemyRuntimeData data) {
        var desiredState = ToState(data);
        
        Debug.Log(desiredState);
        
        fsm.ChangeState(desiredState);
        
        fsm.Tick(data);
    }
    
    EnemyBaseState ToState(EnemyRuntimeData data) {
        return data.StateType switch
        {
            EnemyStateType.Idle => idleState,
            EnemyStateType.Chase => chaseState,
            EnemyStateType.Attack => attackState,
            _ => null
        };
    }
}
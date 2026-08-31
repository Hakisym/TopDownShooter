using UnityEngine;

public class EnemyExecution : MonoBehaviour
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
        if (data.RequestData.RequestAttack) {

            data.State = EnemyState.Attack;
            
            var desiredState = ToState(data.State);
        
            fsm.ChangeState(desiredState, data);
        }

        if (data.RequestData.RequestChase) {
            data.State = EnemyState.Chase;
            
            var desiredState = ToState(data.State);
        
            fsm.ChangeState(desiredState, data);
        }
        
        fsm.Tick(data);
    }
    
    EnemyBaseState ToState(EnemyState state) {
        return state switch
        {
            EnemyState.Idle => idleState,
            EnemyState.Chase => chaseState,
            EnemyState.Attack => attackState,
            _ => null
        };
    }
}
using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyTarget target;
    [SerializeField] EnemyMovement movement;
    [SerializeField] EnemyAttack attack;
    [SerializeField] EnemyAnimator animator;

    EnemyFSM fsm;

    EnemyChaseState chaseState;
    EnemyAttackState attackState;
    EnemyIdleState idleState;
    
    public EnemyMovement Movement => movement;
    public EnemyTarget Target => target;
    public EnemyAnimator Animator => animator;

    void Awake() {
        fsm = new EnemyFSM();

        idleState = new EnemyIdleState(this);
        chaseState = new EnemyChaseState(this);
        attackState = new EnemyAttackState(this);
    }

    void Start() {
        fsm.ChangeState(idleState);
    }

    void Update() {
        fsm.Tick();
    }
}
using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public event Action OnBeginAttack;
    [SerializeField] EnemyAttackData data;
    float elapsedTime;

    bool hitTriggered;
    bool recoveryTriggered;

    public void Begin(EnemyRuntimeData runtimeData) {
        elapsedTime = 0f;

        hitTriggered = false;
        recoveryTriggered = false;
        
        runtimeData.ActionData.CurrentAction = EnemyAction.Attack;
        runtimeData.ActionData.AttackPhase = AttackPhase.Startup;
        
        OnBeginAttack?.Invoke();
    }

    public void Tick(EnemyRuntimeData runtimeData) {
        elapsedTime += Time.deltaTime;

        if (!hitTriggered && elapsedTime >= data.hitTime) {
            hitTriggered = true;

            Hit(runtimeData);

            runtimeData.ActionData.AttackPhase = AttackPhase.Active;
        }
        
        if (!recoveryTriggered && elapsedTime >= data.recoveryTime) {
            recoveryTriggered = true;
            
            runtimeData.ActionData.AttackPhase = AttackPhase.Recovery;
        }

        if (elapsedTime >= data.duration) {
            Finish(runtimeData);
        }
    }

    void Hit(EnemyRuntimeData runtimeData) {
        // hit detection
        // damage
    }

    public void Finish(EnemyRuntimeData runtimeData) {
        runtimeData.ActionData.CurrentAction = EnemyAction.None;
        runtimeData.ActionData.AttackPhase = AttackPhase.None;
    }
}
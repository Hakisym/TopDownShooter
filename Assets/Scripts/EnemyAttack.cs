using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public event Action OnBeginAttack;
    [SerializeField] EnemyAttackData attackData;
    float elapsedTime;
    
    public void Tick(EnemyRuntimeData runtimeData) {
        if (runtimeData.CommandData.BeginAttack)
            Begin(runtimeData);

        if (runtimeData.ActionData.CurrentAction != EnemyAction.Attack) 
            return;
        
        UpdateAttack(runtimeData);
    }
    
    void Begin(EnemyRuntimeData runtimeData) {
        elapsedTime = 0f;
        
        runtimeData.ActionData.CurrentAction = EnemyAction.Attack;
        runtimeData.ActionData.AttackPhase = AttackPhase.Startup;
        
        OnBeginAttack?.Invoke();
    }

    void UpdateAttack(EnemyRuntimeData runtimeData) {
        elapsedTime += Time.deltaTime;

        if (runtimeData.ActionData.AttackPhase == AttackPhase.Startup && 
            elapsedTime >= attackData.hitTime) {
            runtimeData.ActionData.AttackPhase = AttackPhase.Active;
            
            Hit(runtimeData);
        }
        
        if (runtimeData.ActionData.AttackPhase == AttackPhase.Active && 
            elapsedTime >= attackData.recoveryTime) {
            runtimeData.ActionData.AttackPhase = AttackPhase.Recovery;
        }

        if (elapsedTime >= attackData.duration) {
            Finish(runtimeData);
        }
    }

    void Hit(EnemyRuntimeData runtimeData) {
        // hit detection
        // damage
    }

    void Finish(EnemyRuntimeData runtimeData) {
        runtimeData.ActionData.CurrentAction = EnemyAction.None;
        runtimeData.ActionData.AttackPhase = AttackPhase.None;
        
        runtimeData.ResultData.EnemyAttackFinished = true;
    }
}
using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public event Action OnBeginAttack;
    [SerializeField] EnemyData enemyData;
    float elapsedTime;
    
    public void Tick(EnemyRuntimeData runtimeData) {
        if (runtimeData.CommandData.BeginAttack)
            Begin(runtimeData);

        if (runtimeData.ActionData.CurrentAction == EnemyAction.None) 
            return;
        
        UpdateAttack(runtimeData);
    }
    
    void Begin(EnemyRuntimeData runtimeData) {
        if (runtimeData.ActionData.CurrentAction == EnemyAction.Attack)
            return;
        
        elapsedTime = 0f;
        
        runtimeData.ActionData.CurrentAction = EnemyAction.Attack;
        runtimeData.ActionData.AttackPhase = AttackPhase.Startup;
        
        OnBeginAttack?.Invoke();
    }

    void UpdateAttack(EnemyRuntimeData runtimeData) {
        elapsedTime += Time.deltaTime;

        runtimeData.ActionData.CanRotate = true;
        
        if (runtimeData.ActionData.AttackPhase == AttackPhase.Startup && 
            elapsedTime >= enemyData.hitTime) {
            runtimeData.ActionData.AttackPhase = AttackPhase.Active;
            
            Hit(runtimeData);
            return;
        }
        
        if (runtimeData.ActionData.AttackPhase == AttackPhase.Active && 
            elapsedTime >= enemyData.recoveryTime) {
            runtimeData.ActionData.AttackPhase = AttackPhase.Recovery;
        }

        if (elapsedTime >= enemyData.duration) {
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
        
        runtimeData.ActionData.CanRotate = false;
    }
}
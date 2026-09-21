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
            elapsedTime >= enemyData.attack.hitTime) {
            runtimeData.ActionData.AttackPhase = AttackPhase.Active;
            
            Hit(runtimeData);
            return;
        }
        
        if (runtimeData.ActionData.AttackPhase == AttackPhase.Active && 
            elapsedTime >= enemyData.attack.recoveryTime) {
            runtimeData.ActionData.AttackPhase = AttackPhase.Recovery;
        }

        if (elapsedTime >= enemyData.attack.duration) {
            Finish(runtimeData);
        }
    }

    void Hit(EnemyRuntimeData runtimeData) {
        var perception = runtimeData.PerceptionData;
        var target = perception.CurrentTarget;

        if (!target)
            return;

        // 攻击前摇期间玩家可能已经跑远
        if (perception.DistanceToTarget > enemyData.attack.range)
            return;

        // attackData.angle表示整个扇形角度
        var angleToTarget = Vector3.Angle(
            transform.forward,
            perception.DirectionToTarget
        );

        if (angleToTarget > enemyData.attack.angle)
            return;

        var damageable = target.GetComponentInParent<IDamageable>();

        damageable?.TakeDamage(enemyData.attack.damage);
    }

    void Finish(EnemyRuntimeData runtimeData) {
        runtimeData.ActionData.CurrentAction = EnemyAction.None;
        runtimeData.ActionData.AttackPhase = AttackPhase.None;
        
        runtimeData.ResultData.EnemyAttackFinished = true;
        
        runtimeData.ActionData.CanRotate = false;
    }
}
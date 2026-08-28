using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    static readonly int IdleHash = Animator.StringToHash("Zombie_Idle");
    static readonly int WalkHash = Animator.StringToHash("Zombie_Walk");
    static readonly int AttackHash = Animator.StringToHash("Zombie_Attack");
    
    [SerializeField] Animator animator;

    int currentAnimation;

    public void Tick(EnemyRuntimeData data) {
        var targetAnimation = GetTargetAnimation(data.StateType);

        PlayAnimation(targetAnimation);
    }

    int GetTargetAnimation(EnemyStateType stateType) {
        return stateType switch {
            EnemyStateType.Idle => IdleHash,
            EnemyStateType.Chase => WalkHash,
            EnemyStateType.Attack => AttackHash,
            _ => IdleHash
        };
    }

    void PlayAnimation(int animationHash) {
        if (currentAnimation == animationHash)
            return;

        currentAnimation = animationHash;
        
        animator.CrossFade(animationHash, 0.2f);
    }
}
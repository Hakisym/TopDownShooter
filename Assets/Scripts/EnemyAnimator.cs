using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    static readonly int IdleHash = Animator.StringToHash("Zombie_Idle");
    static readonly int WalkHash = Animator.StringToHash("Zombie_Walk");
    static readonly int AttackHash = Animator.StringToHash("Zombie_Attack");
    
    [SerializeField] Animator animator;
    [SerializeField] EnemyAttack enemyAttack;

    int currentAnimation;

    void Start() {
        enemyAttack.OnBeginAttack += EnemyAttack_OnBeginAttack;
    }

    void EnemyAttack_OnBeginAttack() {
        PlayOneShotAnimation(AttackHash);
    }

    public void Tick(EnemyRuntimeData data) {
        if (!data.MovementData.IsMoving
            && data.ActionData.CurrentAction == EnemyAction.None) {
            PlayLoopedAnimation(IdleHash);
        }
        
        if (data.MovementData.IsMoving) {
            PlayLoopedAnimation(WalkHash);
        }
    }

    void PlayLoopedAnimation(int animationHash) {
        if (currentAnimation == animationHash)
            return;

        currentAnimation = animationHash;
        
        animator.CrossFade(animationHash, 0.1f);
    }

    void PlayOneShotAnimation(int animationHash) {
        currentAnimation = animationHash;
        animator.CrossFadeInFixedTime(animationHash, 0.1f);
    }
}
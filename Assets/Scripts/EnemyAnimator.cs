using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    static readonly int IdleHash = Animator.StringToHash("Zombie_Idle");
    static readonly int WalkHash = Animator.StringToHash("Zombie_Walk");
    static readonly int AttackHash = Animator.StringToHash("Zombie_Attack");
    static readonly int DeathHash = Animator.StringToHash("Zombie_Dying");
    
    [SerializeField] Animator animator;
    [SerializeField] EnemyAttack enemyAttack;
    [SerializeField] EnemyHealth enemyHealth;

    int currentAnimation;

    void Start() {
        enemyAttack.OnBeginAttack += EnemyAttack_OnBeginAttack;
        enemyHealth.OnEnemyDied += EnemyHealth_OnEnemyDied;
    }

    void EnemyHealth_OnEnemyDied() {
        PlayOneShotAnimation(DeathHash,0.2f);
    }

    void EnemyAttack_OnBeginAttack() {
        PlayOneShotAnimation(AttackHash);
    }

    public void Tick(EnemyRuntimeData data) {
        if (data.ActionData.CurrentAction == EnemyAction.Attack)
            return;

        // Skip attack end frame
        if (data.ResultData.EnemyAttackFinished)
            return;
        
        if (data.MovementData.IsMoving) {
            PlayLoopedAnimation(WalkHash);
        }
        else {
            PlayLoopedAnimation(IdleHash);
        }
    }

    void PlayLoopedAnimation(int animationHash) {
        if (currentAnimation == animationHash)
            return;

        currentAnimation = animationHash;
        
        animator.CrossFade(animationHash, 0.1f);
    }

    void PlayOneShotAnimation(int animationHash, float transitionTime = 0.1f) {
        currentAnimation = animationHash;
        animator.CrossFadeInFixedTime(animationHash, transitionTime);
    }
}
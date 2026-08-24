using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public static readonly int IdleHash = Animator.StringToHash("Zombie_Idle");
    public static readonly int WalkHash = Animator.StringToHash("Zombie_Walk");
    public static readonly int AttackHash = Animator.StringToHash("Zombie_Attack");
    
    [SerializeField] Animator animator;
    

    public void PlayAnimation(int animationHash) {
        animator.CrossFade(animationHash, 0.5f);
    }
}
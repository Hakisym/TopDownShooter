using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float attackInterval = 1f;

    float nextAttackTime;

    public void TryAttack() {
        if (Time.time < nextAttackTime)
            return;

        nextAttackTime = Time.time + attackInterval;
    }
}
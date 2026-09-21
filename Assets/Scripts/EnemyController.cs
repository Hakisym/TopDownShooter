using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    [SerializeField] EnemyPerception perception;
    [SerializeField] EnemyAttack attack;
    [SerializeField] EnemyMovement movement;
    [SerializeField] EnemyAnimator animator;
    
    EnemyRuntimeData data;
    EnemyIntention intention;
    EnemyArbitration arbitration;
    EnemyExecution execution;

    void Awake() {
        data = new EnemyRuntimeData(transform);
        intention = new EnemyIntention(enemyData);
        arbitration = new EnemyArbitration();
        execution = new EnemyExecution();
    }

    void Update() {
        // One-frame decision pipeline
        perception.Tick(data);
        intention.Tick(data);
        arbitration.Tick(data);
        execution.Tick(data);
        
        // Domain systems consume commands and publish actual facts
        attack.Tick(data);
        movement.Tick(data);
        animator.Tick(data);

        // Commands, requests and results must not leak to next frame
        data.CleanFrame();
    }
}
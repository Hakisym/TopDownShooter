using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyPerception perception;
    [SerializeField] EnemyIntention intention;
    [SerializeField] EnemyStateUpdate stateUpdate;
    [SerializeField] EnemyRequest request;
    [SerializeField] EnemyArbitration arbitration;
    [SerializeField] EnemyExecution execution;
    [SerializeField] EnemyAnimator animator;
    
    EnemyRuntimeData data;

    void Awake() {
        data = new EnemyRuntimeData(transform);
    }

    void Update() {
        perception.Tick(data);
        intention.Tick(data);
        stateUpdate.Tick(data);
        request.Tick(data);
        arbitration.Tick(data);
        
        execution.Tick(data);
        animator.Tick(data);

        ClearRuntimeData();
    }

    void ClearRuntimeData() {
        data.IntentData.WantToAttack = false;
        data.IntentData.WantToChase = false;

        data.RequestData.RequestChase = false;
        data.RequestData.RequestAttack = false;
    }
}
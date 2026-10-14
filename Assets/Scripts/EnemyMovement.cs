using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 180f;

    NavMeshAgent agent;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Tick(EnemyRuntimeData data) {
        data.MovementData.IsRotating = 
            data.ActionData is { CurrentAction: EnemyAction.Attack, CanRotate: true } 
            || data.CommandData.ShouldRotate;
        
        data.MovementData.IsMoving = 
            data.CommandData.ShouldMove;
        
        if (data.MovementData.IsRotating)
            Rotate(data.CommandData.FaceDirection);

        if (data.MovementData.IsMoving) {
            agent.isStopped = false;
            agent.SetDestination(data.CommandData.MoveDestination);
            agent.avoidancePriority = 50;
        }
        else {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            agent.avoidancePriority = 10;
        }
    }

    void Rotate(Vector3 direction) {
        if (direction == Vector3.zero) return;
        
        var targetRotation = Quaternion.LookRotation(direction);
        
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation, targetRotation, 
            rotationSpeed * Time.deltaTime
            );
    }
}
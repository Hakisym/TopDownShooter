using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float rotationSpeed = 180f;

    public void Tick(EnemyRuntimeData data) {
        var moveDirection = data.CommandData.MoveDirection;
        var faceDirection = data.CommandData.FaceDirection;

        if (data.ActionData.CurrentAction == EnemyAction.Attack) {
            faceDirection = data.ActionData.CanRotate
                ? data.PerceptionData.DirectionToTarget
                : Vector3.zero;
        }
        
        data.MovementData.IsMoving = 
            moveDirection.sqrMagnitude > 0.001f;

        data.MovementData.IsRotating =
            faceDirection.sqrMagnitude > 0.001f;

        if (data.MovementData.IsRotating)
            Rotate(faceDirection);
        
        if (data.MovementData.IsMoving)
            Move(moveDirection);
    }

    void Move(Vector3 direction) {
        transform.position += direction * (moveSpeed * Time.deltaTime);
    }

    void Rotate(Vector3 direction) {
        var targetRotation = Quaternion.LookRotation(direction);
        
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation, targetRotation, 
            rotationSpeed * Time.deltaTime
            );
    }
}
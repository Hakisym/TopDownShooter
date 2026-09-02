using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;

    public void Tick(EnemyRuntimeData data) {
        var direction = data.CommandData.MoveDirection;

        data.MovementData.IsMoving = 
            direction.sqrMagnitude > 0.001f;

        if (!data.MovementData.IsMoving) return;
        
        Rotate(direction);
        Move(direction);
    }

    void Move(Vector3 direction) {
        transform.position += direction * (moveSpeed * Time.deltaTime);
    }

    void Rotate(Vector3 direction) {
        transform.LookAt(transform.position + direction);
    }
}
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;

    public void Move(Vector3 direction) {
        transform.position += direction * (moveSpeed * Time.deltaTime);
    }

    public void Rotate(Vector3 direction) {
        transform.LookAt(transform.position + direction);
    }
}
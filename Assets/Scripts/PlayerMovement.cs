using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float groundAcceleration = 80f;
    [SerializeField] float groundDeceleration = 80f;
    
    CharacterController controller;
    
    Vector3 velocity;

    void Awake() {
        controller = GetComponent<CharacterController>();
    }

    Vector3 CalculateHorizontalVelocity(Vector3 moveDir, Vector3 velocity) {
        var lateralVelocity = new Vector3(velocity.x, 0f, velocity.z);

        // 有输入：加速到目标速度
        if (moveDir.sqrMagnitude > 0.01f) {
            Vector3 targetVelocity = moveDir * walkSpeed;
            
            lateralVelocity = Vector3.MoveTowards(
                lateralVelocity,
                targetVelocity,
                groundAcceleration * Time.deltaTime
            );
        }
        else {
            // 只有无输入时才减速
            lateralVelocity = Vector3.MoveTowards(
                lateralVelocity,
                Vector3.zero,
                groundDeceleration * Time.deltaTime
            );
        }

        var newVelocity = new Vector3(lateralVelocity.x, velocity.y, lateralVelocity.z);

        return newVelocity;
    }

    public void Tick(PlayerRuntimeContext ctx) {
        var moveDirection = GetMoveDirection(ctx.InputContext.MoveInput);
        
        velocity = CalculateHorizontalVelocity(moveDirection, velocity);
        
        controller.Move(velocity * Time.deltaTime);
    }

    Vector3 GetMoveDirection(Vector2 moveInput) {
        var inputDir = new Vector3(moveInput.x, 0, moveInput.y);
        return inputDir.normalized;
    }
}
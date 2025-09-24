using UnityEngine;
using UnityEngine.InputSystem; // ✅ New Input System

[RequireComponent(typeof(PlayerInput))] // PlayerInput(Behavior: Invoke Unity Events)
public class PlayerMove_new : MonoBehaviour
{
    [SerializeField] private float speed = 8.0f;

    // Invoke Unity Events의 Move 액션에서 값을 받기 위한 캐시
    private Vector2 move;

    private void Update()
    {
        // 대각선 가속 방지: 키보드(2D 컴포지트)에서만 정규화, 아날로그 스틱의 세기는 보존
        Vector2 step = move;
        if (step.sqrMagnitude > 1f) step = step.normalized;

        Vector3 delta = new Vector3(step.x, step.y, 0f) * speed * Time.deltaTime;
        transform.position += delta;
    }

    // ── PlayerInput(Behavior: Invoke Unity Events)의 Events 섹션에서
    //     Move 액션에 이 함수를 연결하세요.
    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (ctx.canceled) 
        { 
            move = Vector2.zero; 
            return; 
        }
        move = ctx.ReadValue<Vector2>();
    }
}

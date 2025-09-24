알겠습니다 👍
말씀해주신 흐름대로 **기존 코드(구 Input System)** → **수정된 코드(신 Input System 기반)** → **비교/변경점**을 정리한 README 초안을 작성해드릴게요.

---

# Player Movement & Shooting System (Unity)

## 📌 개요

이 프로젝트는 **Unity 플레이어 이동 및 발사 시스템**을 두 가지 방식으로 구현한 예시입니다.

* 기존 코드: **구 Input System (`Input.GetAxis`, `Input.GetKey`) 기반**
* 수정된 코드: **신 Input System (`UnityEngine.InputSystem`) 기반**

신 Input System을 통해 **이벤트 기반 입력 처리**, **키보드/패드 호환성 강화**, **코드 유지보수성 향상**을 구현했습니다.

---

## 🕹️ 기존 코드 (Old Input System)

### 이동 (예시)

```csharp
float h = Input.GetAxis("Horizontal");
float v = Input.GetAxis("Vertical");
Vector3 dir = new Vector3(h, v, 0);
transform.position += dir.normalized * speed * Time.deltaTime;
```

* `Input.GetAxis`로 이동 벡터 계산
* 키보드 입력만 안정적으로 지원
* 아날로그 스틱의 세기(강도)는 반영되지 않음

### 발사 (예시)

```csharp
if (Input.GetKey(KeyCode.Space) && Time.time > lastFire + fireDelay)
{
    Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    ...
}
```

* `Input.GetKey` 기반 지속 발사
* 타이밍은 `Time.time` 비교로 제어
* 입력 이벤트 분리 불가 (누름/홀드/취소 구분 없음)

---

## 🆕 수정된 코드 (New Input System)

### 이동

```csharp
public void OnMove(InputAction.CallbackContext ctx)
{
    if (ctx.canceled) move = Vector2.zero;
    else move = ctx.ReadValue<Vector2>();
}
```

* `PlayerInput (Behavior: Invoke Unity Events)` 사용
* **이벤트 기반 입력 처리** → 키보드/패드 모두 지원
* 대각선 이동 시 **속도 정규화 처리**

### 발사

```csharp
public void OnFire(InputAction.CallbackContext ctx)
{
    if (ctx.started || ctx.performed)
    {
        isFiring = true;
        TryFire(); // 즉시 1발 발사 (지연 제거)
    }
    else if (ctx.canceled)
    {
        isFiring = false;
    }
}
```

* `ctx.started`, `ctx.performed`, `ctx.canceled` 이벤트 구분
  → **눌렀을 때, 누르고 있는 중, 뗐을 때** 모두 처리 가능
* `Update()`에서 `isFiring` 상태 확인 후 `TryFire()` 실행
* `fireDelay`를 활용해 **연사 속도 제한**

---

## 🔄 변경점 요약

| 항목        | 구 Input System                | 신 Input System                                   |
| --------- | ----------------------------- | ------------------------------------------------ |
| **이동**    | `Input.GetAxis`               | `InputAction.CallbackContext` (Move 이벤트)         |
| **발사**    | `Input.GetKey(KeyCode.Space)` | `OnFire` 이벤트 기반 (`started/performed/canceled`)   |
| **입력 방식** | 폴링(Polling) 방식                | 이벤트 기반(Event-driven)                             |
| **호환성**   | 키보드 중심                        | 키보드 + 패드/아날로그 스틱 지원                              |
| **유연성**   | 입력 상태 구분 불가                   | 입력 상태(`started`, `performed`, `canceled`) 명확히 구분 |
| **발사 로직** | Key Down → Delay 체크           | 첫 발 즉시 발사 + 지속 연사 제어                             |

---

## 🚀 실행 방법

1. **Player 오브젝트**에 `PlayerInput` 컴포넌트 추가

   * Behavior: **Invoke Unity Events**
   * Events: Move, Fire 연결
2. `Input Actions` 에서

   * `Move`: `2D Vector Composite (WASD/Stick)`
   * `Fire`: `Button (Space/Gamepad South)` 설정
3. `PlayerMove_new.cs`, `PlayerShootNew.cs`를 Player 오브젝트에 연결
4. Prefab 및 FirePoint Transform 할당 후 실행

---
using UnityEngine;
using UnityEngine.InputSystem; // ✅ New Input System

[RequireComponent(typeof(PlayerInput))] // PlayerInput(Behavior: Invoke Unity Events)
public class PlayerShootNew : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject bulletPrefab; 
    public GameObject bulletPrefab2;
    public GameObject heartPrefab;

    [Header("Muzzles")]
    public Transform firePoint; 
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform rearPosition;

    [Header("Fire Settings")]
    [SerializeField] public float fireDelay = 0.01f;

    private float lastFireTime;
    private bool isFiring; // 버튼 홀드 상태

    private void Update()
    {
        if (isFiring)
            TryFire();
    }

    private void TryFire()
    {
        if (Time.time < lastFireTime + fireDelay)
        {
            //Debug.Log("장전중..");
            return;
        }
        else
        {
            if (bulletPrefab && firePoint)  Instantiate(bulletPrefab,  firePoint.position,  Quaternion.identity);
            if (bulletPrefab && firePoint2) Instantiate(bulletPrefab,  firePoint2.position, Quaternion.identity);
            if (bulletPrefab2 && firePoint3)Instantiate(bulletPrefab2, firePoint3.position, Quaternion.identity);
            if (bulletPrefab2 && firePoint4)Instantiate(bulletPrefab2, firePoint4.position, Quaternion.identity);
            if (heartPrefab && rearPosition)Instantiate(heartPrefab,   rearPosition.position, Quaternion.identity);
            Debug.Log("발사!!");
        }
        lastFireTime = Time.time;
    }

    // PlayerInput(Behavior: Invoke Unity Events) ▸ Events ▸ Fire 에 이 메서드 연결
    public void OnFire(InputAction.CallbackContext ctx)
    {
        // 누르는 순간 즉시 한 발 쏘고(지연감 제거), 홀드 상태로 전환
        if (ctx.started || ctx.performed)
        {
            isFiring = true;
            TryFire();
        }
        else if (ctx.canceled)
        {
            isFiring = false;
        }
    }
}

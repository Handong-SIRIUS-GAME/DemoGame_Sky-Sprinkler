using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; //총알 Prefab
    public GameObject bulletPrefab2;
    public GameObject heartPrefab;
    public Transform firePoint; // 총알 발사 위치
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform rearPosition;
    public float fireDelay = 0.15f; // 발사 딜레이 시간
    private float lastFire = 0.0f; // 마지막으로 발사한 시간

    void Update()
    {
        // 스페이스 키가 눌린 상태로, 딜레이 시간이 초과됐으면
        if(Input.GetKey(KeyCode.Space) && Time.time > lastFire + fireDelay)
        {
            // 총알 prefab을 불러와서 시작 위치에 배치한다.
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Instantiate(bulletPrefab, firePoint2.position, Quaternion.identity);
            Instantiate(bulletPrefab2, firePoint3.position, Quaternion.identity);
            Instantiate(bulletPrefab2, firePoint4.position, Quaternion.identity);
            Instantiate(heartPrefab, rearPosition.position, Quaternion.identity);
            //이 방식은 계속 load를 해야 하는 단점이 있어서 위의 방식이 정석
            //Instantiate(Resources.Load("Bullet"), firePoint.position, Quaternion.identity);
            lastFire = Time.time;
        }
    }
}

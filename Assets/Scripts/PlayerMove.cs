using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 8.0f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //이동할 방향 계산
        Vector3 dir = new Vector3(h, v, 0);

        // 계산한 방향으로 플레이어를 이동시켜 위치를 갱신
        transform.position += dir.normalized * speed * Time.deltaTime;
    }
}

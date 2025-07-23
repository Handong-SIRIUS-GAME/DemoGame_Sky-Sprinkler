using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15.0f;
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        //총알의 y 위치가 7보다 크면
        if(transform.position.y > 7.0f)
        {
            //게임 오브젝트 파괴
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

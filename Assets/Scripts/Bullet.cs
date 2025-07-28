using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15.0f;
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        if(transform.position.y > 7.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameManager.Instance.AddScore(10);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

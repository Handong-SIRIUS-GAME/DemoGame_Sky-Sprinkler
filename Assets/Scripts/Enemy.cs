using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if(transform.position.y < -7.0f)
        {
            Destroy(gameObject);
        }
    }
}

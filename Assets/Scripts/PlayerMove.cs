using UnityEngine;

public class PlayerMove_old : MonoBehaviour
{
    public float speed = 8.0f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, v, 0);
        
        transform.position += dir.normalized * speed * Time.deltaTime;
    }
}

using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float lastFire = 0.0f;
    private float fireDelay = 1.5f;
    private float scaleSize = 1.0f;

    private void Start()
    {
        lastFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(scaleSize, scaleSize, 0.0f);
        scaleSize -= 0.002f;

        if (Time.time > lastFire + fireDelay)
        {
            Destroy(gameObject);
        }
    }
}

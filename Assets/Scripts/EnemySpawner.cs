using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public float spawnDelay = 1.0f;
    float timer = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnDelay)
        {
            float x = Random.Range(-8.0f, 8.0f);
            int chooseEnemy = Random.Range(0, 2);
            GameObject instance = Instantiate(enemyPrefab[chooseEnemy], new Vector3(x, 7.0f, 0.0f), Quaternion.identity);
            timer = 0.0f;

            float randvalue = Random.Range(1.0f, 3.0f);
            instance.transform.localScale = new Vector3(randvalue, randvalue, 0.0f);
            instance.transform.position += Vector3.up * randvalue * Time.deltaTime;


        }
    }
}

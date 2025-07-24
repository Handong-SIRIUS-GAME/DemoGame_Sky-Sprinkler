using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int myScore = 0;
    public TextMeshProUGUI textScore;

    void Awake()
    {
        Instance = this; // 내 자신의 클래스를 저장해둔다.
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textScore.text = myScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        myScore += score;
        textScore.text = myScore.ToString();
    }
}

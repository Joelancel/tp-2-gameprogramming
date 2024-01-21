using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                if (_instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    _instance = obj.AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }

    private float score = 0f;
    public float scoreIncreaseRate = 25f;
    public Text scoreText;

    void Update()
    {
        score += Time.deltaTime * scoreIncreaseRate;
        scoreText.text = "Score: " + Mathf.Round(score);
    }

    public void AddScore(float amount)
    {
        score += amount;
        scoreText.text = "Score: " + Mathf.Round(score);
    }
}
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreToAdd = 222;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.AddScore(scoreToAdd);
        Destroy(gameObject);
    }
}
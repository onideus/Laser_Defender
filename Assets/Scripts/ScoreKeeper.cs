using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private static ScoreKeeper _instance;
    private int _score;

    private void Awake()
    {
        ManageSingleton();
    }

    public int GetScore() => _score;

    public void ModifyScore(int amount)
    {
        _score += amount;
        _score = Mathf.Clamp(_score, 0, int.MaxValue);
        Debug.Log("Score: " + _score);
    }

    public void ResetScore()
    {
        _score = 0;
    }

    private void ManageSingleton()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
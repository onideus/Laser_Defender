using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper _scoreKeeper;

    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        scoreText.text = "You Scored:\n" + _scoreKeeper.GetScore();
    }
}
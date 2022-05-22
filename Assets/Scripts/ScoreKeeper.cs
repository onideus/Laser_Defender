using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int _score;

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
}
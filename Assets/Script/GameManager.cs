using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public event Action<float> UpdateScore;
    float score;
    protected override void Awake()
    {
        MakeSingleton(false);
    }
    public void AddScore(float score)
    {
        this.score += score;
        UpdateScore?.Invoke(this.score);
    }
}

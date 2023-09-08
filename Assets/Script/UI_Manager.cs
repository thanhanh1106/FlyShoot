using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    private void Start()
    {
        GameManager.Instance.UpdateScore += UpdateTextScore;
        UpdateTextScore(0);
    }

    private void UpdateTextScore(float score)
    {
        scoreText.text =  "Score: " +  score.ToString("00");
    }
}

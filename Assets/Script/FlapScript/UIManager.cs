using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   public Text scoreText;
    public Button restartButton; // 🔁 버튼으로 변경

    public void Start()
    {
        if (restartButton == null)
        {
            Debug.LogError("restart button is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        restartButton.gameObject.SetActive(false);

        // 버튼에 이벤트 연결
        restartButton.onClick.AddListener(FlyingManager.Instance.RestartGame);
    }

    public void SetRestart()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlyingManager : MonoBehaviour
{
    static FlyingManager flyingManager;

    public static FlyingManager Instance { get { return flyingManager; } }

    private int currentScore = 0;
    public GameObject EndPanel;
    public Text nowScore;
    public Text bestScore;

    public Button Backbtn;
    public Button RestartBtn;
    UIManager uiManager;

    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        flyingManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
        Backbtn.onClick.AddListener(Back);
        RestartBtn.onClick.AddListener(RestartGame);
    }
    public void GameOver()
    {
        nowScore.text = currentScore.ToString();
        if (PlayerPrefs.HasKey("bestScore"))
        {
            float best = PlayerPrefs.GetInt("bestScore");
            if (best < currentScore)
            {
                PlayerPrefs.SetInt("bestScore", currentScore);
                bestScore.text = currentScore.ToString("N0");
            }
            else
            {
                bestScore.text = best.ToString("N0");
            }
        }
        else
        {
            PlayerPrefs.SetInt("bestScore", currentScore);
            bestScore.text = currentScore.ToString("N0");
        }
        EndPanel.SetActive(true);

        Debug.Log("GameOver");
        uiManager.SetRestart();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score : " + currentScore);
        uiManager.UpdateScore(currentScore);
    }
    void Back()
    {
        SceneManager.LoadScene("MainScene"); // ✅ 원하는 씬 이름으로 변경
    }
}

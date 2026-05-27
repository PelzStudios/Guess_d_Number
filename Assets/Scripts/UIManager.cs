using UnityEngine;
using UnityEngine.UI;
using TMPro;
// using UnityEngine.UIElements;
using System;

/// <summary>
/// Handles UI text updates and panel switching.
/// </summary>

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;

    [Header("Text References")]
    public TMP_Text randomNumberText;
    public TMP_Text attemptsLeftText;
    public TMP_Text hintText;
    public TMP_Text currentStreakText;
    public TMP_Text homeBestStreakText;
    public TMP_Text gameOverBestStreakText;
    
   [Header("Panels")]
    public GameObject homePanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    [Header("Panels")]
    public Image hintArrowUp;
    public Image hintArrowDown;
    



    void Start()
    {
        ShowHomePanel();
    }

    public void ShowHomePanel()
    {
        homePanel.SetActive(true);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    public void ShowGamePanel()
    {
        homePanel.SetActive(false);
        gamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        homePanel.SetActive(false);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        winPanel.SetActive(false);
    }

    public void ShowWinPanel()
    {
        homePanel.SetActive(false);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        winPanel.SetActive(true);
    }

    public void UpdateRandomNumberText()
    {
        randomNumberText.text = gameManager.randomNumberValue.ToString();
    }

    public void UpdateHintText()
    {
        hintText.text = gameManager.hint;
    }

    public void UpdateAttemptsLeftText()
    {
        attemptsLeftText.text = $"Attempts Left: {gameManager.possibleAttempts}";
    }

    public void RefreshUI()
    {
        UpdateAttemptsLeftText();
        UpdateHintText();
        UpdateCurrentStreakText();
        UpdateBestStreakText();
        randomNumberText.text = "?";
    }

    public void UpdateCurrentStreakText()
    {
        currentStreakText.text = $"Current Streak: {gameManager.currentStreak}";
    }

    public void UpdateBestStreakText()
    {
        homeBestStreakText.text = $"Best Streak: {gameManager.bestStreak}";
        gameOverBestStreakText.text = $"Best Streak: {gameManager.bestStreak}";
    }
}
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;

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

    [Header("End Screen Opponent Card Number References")]
    public TMP_Text winOpponentNumberText;
    public TMP_Text gameOverOpponentNumberText;

    [Header("Current Streak Text References")]
    public TMP_Text winCurrentStreakText;
    public TMP_Text gameOverCurrentStreakText;

    [Header("Best Streak Text References")]
    public TMP_Text homeBestStreakText;
    public TMP_Text winBestStreakText;
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

    void OnEnable()
    {
        GameEvents.OnSessionEnded += ShowOpponentNumberAfterSession;
    }

    void OnDisable()
    {
        GameEvents.OnSessionEnded -= ShowOpponentNumberAfterSession;
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
        attemptsLeftText.text = $"{gameManager.possibleAttempts}/7";
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
        winCurrentStreakText.text = $"{gameManager.currentStreak}";
        gameOverCurrentStreakText.text = $"{gameManager.currentStreak}";
    }

    public void UpdateBestStreakText()
    {
        homeBestStreakText.text = $"Best Streak: {gameManager.bestStreak}";
        winBestStreakText.text = $"{gameManager.bestStreak}";
        gameOverBestStreakText.text = $"{gameManager.bestStreak}";
    }

    public void ShowOpponentNumberAfterSession()
    {
        winOpponentNumberText.text = $"{gameManager.randomNumberValue}";
        gameOverOpponentNumberText.text = $"{gameManager.randomNumberValue}";
    }

    public IEnumerator HintUpArrowSequence()
    {
        hintArrowUp.color = Color.green;
        gameManager.hint = "Go Higher!";

        yield return new WaitForSeconds(2f);

        hintArrowUp.color = Color.white;
        hintText.text = "";

    }

    public IEnumerator HintDownArrowSequence()
    {
        hintArrowDown.color = Color.green;
        gameManager.hint = "Go Lower!";

        yield return new WaitForSeconds(2f);

        hintArrowDown.color = Color.white;
        hintText.text = "";

    }
}
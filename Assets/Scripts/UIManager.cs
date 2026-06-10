using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using Unity.VisualScripting;

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

    [Header("Panel Elements")]
    public List<GameObject> homePanelElements = new List<GameObject>();
    public List<GameObject> winPanelElements = new List<GameObject>();
    public List<GameObject> gameOverPanelElements = new List<GameObject>();
    


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
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        // PopUpPanel(homePanel);
        homePanel.SetActive(true);

        KillElements(homePanelElements);
        StartCoroutine(PopUpSequence(homePanelElements));
    }

    public void ShowGamePanel()
    {
        homePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        // PopUpPanel(gamePanel);
        gamePanel.SetActive(true);
    }

    public void ShowGameOverPanel()
    {
        homePanel.SetActive(false);
        gamePanel.SetActive(false);
        winPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        // PopUpPanel(gameOverPanel);

        KillElements(gameOverPanelElements);
        StartCoroutine(PopUpSequence(gameOverPanelElements));
    }

    public void ShowWinPanel()
    {
        homePanel.SetActive(false);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        // PopUpPanel(winPanel);
        winPanel.SetActive(true);

        KillElements(winPanelElements);
        StartCoroutine(PopUpSequence(winPanelElements));
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

    public void PopUpPanel(GameObject panel)
    {
        panel.SetActive(true);
        panel.transform.localScale = Vector3.zero;
        panel.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
    }

    public Tween PopUpElement(GameObject uiElement)
    {
        uiElement.SetActive(true);
        Vector3 originalScale = uiElement.transform.localScale;  // storing its original scale
        uiElement.transform.localScale = Vector3.zero;
        Tween tween = uiElement.transform.DOScale(originalScale, 0.13f).SetEase(Ease.OutBack);
        return tween;
    }

    public void KillElements(List<GameObject> uiElements)
    {
        foreach (GameObject element in uiElements)
        {
            element.SetActive(false);
        }
    }

    public IEnumerator PopUpSequence(List<GameObject> elements)
    {
        foreach (GameObject element in elements)
        {
            Tween mytween = PopUpElement(element);
            yield return mytween.WaitForCompletion(); 
             
        }
    }

    public void ButtonTapBounce()
    {
        transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.1f, 1, 1);
    }
}
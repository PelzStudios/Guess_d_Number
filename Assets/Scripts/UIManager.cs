using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text randomNumberText;
    public TMP_Text attemptsLeftText;

   [Header("Panels")]
    public GameObject homePanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;


    // update random number text on UI
    // update attempts left text on UI
    // switch between panels based on game state

    public void ShowHomePanel()
    {
        homePanel.SetActive(true);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void ShowGamePanel()
    {
        homePanel.SetActive(false);
        gamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        homePanel.SetActive(false);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void ShowWinPanel()
    {
        homePanel.SetActive(false);
        gamePanel.SetActive(false);
        winPanel.SetActive(true);
    }

    public void UpdateRandomNumberText()
    {
        randomNumberText.text = gameManager.randomNumberValue.ToString();
    }

    public void UpdateAttemptsLeftText()
    {
        attemptsLeftText.text = gameManager.possibleAttempts.ToString();
    }


}
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


    // update random number text on UI
    // update attempts left text on UI
    // switch between panels based on game state

    public void ShowHomePanel(){}
    public void ShowGamePanel(){}
    public void ShowGameOverPanel(){}
    public void UpdateRandomNumberText(){}
    public void UpdateAttemptsLeftText(){}
    


}
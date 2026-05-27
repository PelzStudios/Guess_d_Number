using System.Collections;
// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Central hub for number guessing logic and game states flow
/// </summary>

public class GameManager : MonoBehaviour
{
    public GameManager Instance { get; private set; }
    
    public GameState gameState;
    public Stage cardSlots;
    public int randomNumberValue;  // number to guess (opponent)
    public int possibleAttempts = 7;
    public int currentStreak = 0;
    public int bestStreak = 0;
    public string hint;
    private CardManager cardManager;

    private UIManager uiManager;
    private int guessValue;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        uiManager = FindFirstObjectByType<UIManager>();
        cardManager = FindFirstObjectByType<CardManager>();

        LoadBestStreakData();
        uiManager.RefreshUI();

    }

    public void GetRandomNumberValue()  // generate random number within 1 and 100 for player to guess
    {
        randomNumberValue = Random.Range(0, 100);
        Debug.Log("Selecting random number between " + 0 + " and " + 100 + " " + "Random Number is: " + randomNumberValue);
    }

    public void GetCombinedGuessValue()  // get player's guess value
    {
        guessValue = cardSlots.GuessValueInt;
    }

    public void CheckGuess()
    {
        foreach (Transform slot in cardSlots.transform)
        {
            if (slot.GetComponent<CardSlot>().isOccupied == false) return;
        }
        
        GetCombinedGuessValue();
        
        if (randomNumberValue == guessValue) 
        {
            StartCoroutine(WinSequence()); 
            return;
        }

        ReduceAttempts();
        
        ShowHint();

        uiManager.RefreshUI();
    }

    public void ReduceAttempts()
    {
        possibleAttempts--;

        if(possibleAttempts <= 0)
        {
            GameOver();
        }
    }


    public void GoHome()
    {
        gameState = GameState.Home;
        LoadBestStreakData();
        uiManager.RefreshUI();
        uiManager.ShowHomePanel();
    }

    public void NewGame()
    {   
        gameState = GameState.Playing;
        ResetGameData();
        GetRandomNumberValue();
        uiManager.ShowGamePanel();
        uiManager.RefreshUI();
    }  


    public void GameOver()
    {
        gameState = GameState.GameOver;
        uiManager.ShowGameOverPanel();
        currentStreak = 0;
    }

    public void ResetGameData()
    {
        possibleAttempts = 7;
        cardManager.ResetCardSlots();
        hint = "";
    }

    private IEnumerator WinSequence()
    {
        gameState = GameState.Win;

        currentStreak++;

        if (currentStreak > bestStreak)
        {
            bestStreak = currentStreak;
            PlayerPrefs.SetInt("Best Streak", bestStreak);
            PlayerPrefs.Save();
        }

        uiManager.UpdateRandomNumberText();

        yield return new WaitForSeconds(2f);
        uiManager.ShowWinPanel();
    }
    
    public void ShowHint()
    {
        if (randomNumberValue < guessValue)
        {
            uiManager.StartCoroutine(HintDownArrowSequence());
        } 
        
        if (randomNumberValue > guessValue)
        {
            uiManager.StartCoroutine(HintUpArrowSequence());
        } 
    }

    private IEnumerator HintUpArrowSequence()
    {
        uiManager.hintArrowUp.color = Color.green;
        hint = "Go Higher!";

        yield return new WaitForSeconds(2f);

        uiManager.hintArrowUp.color = Color.white;
        uiManager.hintText.text = "";

    }

    private IEnumerator HintDownArrowSequence()
    {
        uiManager.hintArrowDown.color = Color.green;
        hint = "Go Lower!";

        yield return new WaitForSeconds(2f);

        uiManager.hintArrowDown.color = Color.white;
        uiManager.hintText.text = "";
    }

    public void LoadBestStreakData()
    {
        bestStreak = PlayerPrefs.GetInt("Best Streak", 0);
    }
}

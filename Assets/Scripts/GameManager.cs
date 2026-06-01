using System.Collections;
using UnityEngine;

/// <summary>
/// Central hub for number guessing logic and game states flow
/// </summary>

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
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
        else
        {
            Destroy(gameObject);
            return;
        }

        cardManager = FindFirstObjectByType<CardManager>();
        uiManager = FindFirstObjectByType<UIManager>();

        LoadStreakData();
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

/// <summary>
/// Function called when "send" button is clicked
/// - Prevents validating empty slots
/// - Grabs player's combined guess value and validates it
/// - Reduces attempts by 1 on every button click
/// - Show hint on every incorrect guess
/// </summary>
    public void CheckGuess()
    {
        foreach (Transform slot in cardSlots.transform)  // to prevent validating empty slots
        {
            CardSlot slotComponent = slot.GetComponent<CardSlot>();

            if (slotComponent.isOccupied == false) return;
        }
        
        GetCombinedGuessValue();
        
        if (randomNumberValue == guessValue)  // win condition
        {
            StartCoroutine(WinSequence()); 
            return;
        }

        ReduceAttempts();
        
        ShowHint();

        uiManager.RefreshUI();
    }

/// <summary>
/// Reduce attempt logic block & Game over initializer
/// </summary>
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
        LoadStreakData();
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

/// <summary>
/// Clean slate initializer for every new game
/// </summary>
    public void ResetGameData()
    {
        possibleAttempts = 7;
        cardManager.ResetCardSlots();
        hint = "";
    }

/// <summary>
/// Coroutine sequence that plays when win condition is met
/// - updates current streak value by 1 (then saves progress)
/// - updates best streak value if surpassed (then saves)
/// - Reveals Mystery Number -> Win Screen
/// </summary>
    private IEnumerator WinSequence()
    {
        gameState = GameState.Win;

        currentStreak++;
        SaveCurrentStreakData(); 

        if (currentStreak > bestStreak)
        {
            bestStreak = currentStreak;
            SaveBestStreakData();
        }

        uiManager.UpdateRandomNumberText();

        yield return new WaitForSeconds(2f);

        uiManager.ShowWinPanel();
    }
    
/// <summary>
/// Calls hint logic from UIManager
/// - Based on player's guess displays arrow and text hints
/// </summary>
    public void ShowHint()
    {
        if (randomNumberValue < guessValue)
        {
            StartCoroutine(uiManager.HintDownArrowSequence());
        } 
        
        if (randomNumberValue > guessValue)
        {
            StartCoroutine(uiManager.HintUpArrowSequence());
        } 
    }


/// <summary>
/// Streak data load system (Current streak & Best streak)
/// </summary>
    public void LoadStreakData()
    {
        bestStreak = PlayerPrefs.GetInt("Best Streak", 0);
        currentStreak = PlayerPrefs.GetInt("Current Streak", 0);
    }

/// <summary>
/// Current streak data save system
/// </summary>
    public void SaveCurrentStreakData()
    {
        PlayerPrefs.SetInt("Current Streak", currentStreak);
        PlayerPrefs.Save();
    }

/// <summary>
/// Best streak data save system
/// </summary>
    public void SaveBestStreakData()
    {
        PlayerPrefs.SetInt("Best Streak", bestStreak);
        PlayerPrefs.Save();
    }
}

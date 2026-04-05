using UnityEngine;

public class GameManager : MonoBehaviour
{
    // singleton pattern implementation
    // set game state to none
    // avoid null exceptions
    
    // reset game state to playing for new game session

    // get random number value from random number selector

    // on every guess, reduce possible attempts by 1

    // get combined guess value from both card slots

    // compare combined guess value with random number value, if correct win

    // if attempts run out, game over

    public GameManager Instance { get; private set; }
    public GameState gameState;
    private RandomNumberSelector randomNumberSelector;
    public int randomNumberValue;
    private int guessValue;
    public int possibleAttempts = 5;
    
    public CardSlots cardSlots;
    private UIManager uiManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        gameState = GameState.Playing;
    }
    
    public void GetRandomNumberValue()
    {
        randomNumberValue = randomNumberSelector.selectedNumber;
    }

    public void GetCombinedGuessValue()
    {
        guessValue = cardSlots.combinedGuessValue;
    }

    public void CheckGuess()
    {
        if (randomNumberValue == guessValue)
        {
            WinGame();
        }
    }

    public void ReduceAttempts()
    {
        possibleAttempts--;

        if(possibleAttempts <= 0)
        {
            GameOver();
        }
    }

    public void NewGame()
    {
        gameState = GameState.Playing;
        possibleAttempts = 5;
        uiManager.ShowGamePanel();
        GetRandomNumberValue();
    }    
    public void WinGame()
    {
        gameState = GameState.Win;
        uiManager.ShowWinPanel();
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
        uiManager.ShowGameOverPanel();
    }
}

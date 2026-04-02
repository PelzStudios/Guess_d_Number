using UnityEngine;

public enum GameState
{
    None,
    Playing,
    Success,
    GameOver
}

public class GameManager : MonoBehaviour
{
 
    public GameManager Instance { get; private set; }

    public GameState gameState;
    public int guessNumberValue;
    public int randomNumberValue;
    public int possibleAttempts = 5;

    public KeyInputManager keyInputManager;

    void Awake()
    {
        // singleton pattern implementation
        // set game state to none
        // avoid null exceptions

        if (Instance == null)
        {
            Instance = this;
            gameState = GameState.None;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void StartGame()
    {
        // set game state to playing
        gameState = GameState.Playing;

   
    }

    void GameOver()
    {
        // set game state to game over
        if (possibleAttempts <= 0)
        {
            gameState = GameState.GameOver;
        }
        
    }

    void NumberGuessed()
    {
        // set game state to success
        if (guessNumberValue == randomNumberValue)
        {
            gameState = GameState.Success;
        }
    }

    

    void Update()
    {
        // keyInputManager.HandleInput();
    }
}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance { get; private set; }
    public GameState gameState;
    public RandomNumberSelector randomNumberSelector;
    public int randomNumberValue;
    public int possibleAttempts = 5;

    public CardSlots cardSlots;

        // singleton pattern implementation
        // set game state to none
        // avoid null exceptions
    
        // reset game state to playing for new game session

        // get random number value from random number selector

        // on every guess, reduce possible attempts by 1

        // get combined guess value from both card slots

        // compare combined guess value with random number value, if correct win

        // if attempts run out, game over

    public void GameOver(){}
    public void GetRandomNumberValue(){}
    public void GetCombinedGuessValue(){}
    public void CheckGuess(){}
    public void ReduceAttempts(){}
    public void NewGame(){}    

 
}

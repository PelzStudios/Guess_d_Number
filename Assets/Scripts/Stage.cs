using UnityEngine;

/// <summary>
/// Retrieves card values from each card slot on stage and 
/// stores combined guess value to compare with random number value
/// </summary>

public class Stage : MonoBehaviour
{
    public CardSlot cardSlot1;
    public CardSlot cardSlot2;

    public string guessCardValue1;
    public string guessCardValue2;

    public string combinedGuessValue;
    public int GuessValueInt;

    void Update()
    {
        GetCombinedGuessValue();
    }

    // void OnEnable()
    // {
    //     GameEvents.OnCardEntered += GetCombinedGuessValue;
    // }

    // void OnDisable()
    // {
    //     GameEvents.OnCardEntered -= GetCombinedGuessValue;
    // }

    public void GetCombinedGuessValue()  // combine both values from each slot into a single double digit value
    {
        guessCardValue1 = cardSlot1.guessCardValue;
        guessCardValue2 = cardSlot2.guessCardValue;
        combinedGuessValue = guessCardValue1 + guessCardValue2;
        int.TryParse(combinedGuessValue, out GuessValueInt);
    }
}
  
 
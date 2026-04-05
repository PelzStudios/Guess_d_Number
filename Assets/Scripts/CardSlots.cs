using UnityEngine;

public class CardSlots : MonoBehaviour
{
    public CardSlot cardSlot1;
    public CardSlot cardSlot2;

    public int guessCardValue1;
    public int guessCardValue2;

    public int combinedGuessValue;

    // get guess card value from each card slot
    // store combined guess value for comparison with random number value in game manager
    // drop area logic for cards

    public void GetCombinedGuessValue()
    {
        cardSlot1.GetGuessCardValue();
        cardSlot2.GetGuessCardValue();
        guessCardValue1 = cardSlot1.guessCardValue;
        guessCardValue2 = cardSlot2.guessCardValue;
        combinedGuessValue = guessCardValue1 + guessCardValue2;
    }
}
  
 
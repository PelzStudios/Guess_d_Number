using UnityEngine;

/// <summary>
/// Retreives value from card in slot and stores it.
/// </summary>

public class CardSlot : MonoBehaviour
{
    public Card card; 
    public bool isOccupied;

    public string guessCardValue;  // string value from card

    // get guess card value from each card
    // store guess card value

   void Update()
    {
        if (isOccupied == true)
        {
            card = GetComponentInChildren<Card>();
            GetGuessCardValue();
        }
    }

    public void GetGuessCardValue()  // get the value from card
    {
        if (card != null)
        {
           guessCardValue = card.cardValue;
        }
    }
}
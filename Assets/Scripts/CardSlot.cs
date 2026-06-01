using UnityEngine;

/// <summary>
/// Retreives value from card in slot and stores it.
/// </summary>

public class CardSlot : MonoBehaviour
{
    public Card card; 
    public bool isOccupied = false;

    public string guessCardValue;  // string value from card

    void OnEnable()
    {
       GameEvents.OnCardEntered += GetGuessCardValue; 
    }

    void OnDisable()
    {
        GameEvents.OnCardEntered -= GetGuessCardValue;
    }


    public void GetGuessCardValue()  // get the value from card
    {
        card = GetComponentInChildren<Card>(); 

        if (card != null)
        {
           guessCardValue = card.cardValue;
        }
    }
}
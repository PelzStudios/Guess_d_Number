using UnityEngine;

/// <summary>
/// Retreives value from card in slot and stores it.
/// </summary>

public class CardSlot : MonoBehaviour
{
    public Card card; 
    public bool isOccupied = false;
    public int guessCardNo;

    void OnEnable()
    {
       GameEvents.OnCardEntered += GetGuessCardNo; 
    }

    void OnDisable()
    {
        GameEvents.OnCardEntered -= GetGuessCardNo; 
    }

    public void GetGuessCardNo()
    {
        card = GetComponentInChildren<Card>();

        if (card != null)
        {
            guessCardNo = card.cardNumber;
        }
    }
}
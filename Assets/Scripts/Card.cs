using UnityEngine;

/// <summary>
/// Handles indiviual card behaviour.
/// Holds card value and detects card selection
/// </summary>

public class Card : MonoBehaviour
{
    // get card value from card and store it
    
    public int cardNumber;
    public string cardValue;

    public bool isDuplicate;  // ghost card

    private CardManager cardManager;
    
    void Awake()
    {
        cardManager = FindFirstObjectByType<CardManager>();
    }
    public void GetCardValue()  // get card value as string and store it
    {
        Debug.Log("Getting card value for " + cardNumber);
        cardValue = cardNumber.ToString(); 
    }

    public void SelectCard()
    {
        if (isDuplicate)  // if the card tapped is the duplicate in the slot, destroy it
        {
            transform.parent.GetComponent<CardSlot>().isOccupied = false;
            Destroy(gameObject);
        }
        else  // if tapped card is original, trigger card select
        {
            cardManager.cardObject = gameObject;  // set selected card as active card in card manager
            cardManager.HandleCardSelected(this);
        }
        
    }
}
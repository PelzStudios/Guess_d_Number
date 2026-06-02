using UnityEngine;

/// <summary>
/// Handles indiviual card behaviour.
/// Holds card value and detects card selection
/// </summary>

public class Card : MonoBehaviour
{   
    public int cardNumber;
    public bool isDuplicate;  // ghost card

    public Transform originalPosition;

    private CardManager cardManager;
    
    void Awake()
    {
        cardManager = FindFirstObjectByType<CardManager>();
    }

/// <summary>
/// Function triggered when a card is selected
/// - Initiates logic based on type of card selected (normal / duplicate)
/// </summary>

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
            cardManager.HandleCardSelected();
        }
    }
}
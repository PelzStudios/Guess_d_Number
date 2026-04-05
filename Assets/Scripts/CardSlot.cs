using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlot : MonoBehaviour, IDropHandler
{
    private Card card; // supposed to be the card dropped into the slot

    public int guessCardValue;

    // get guess card value from each card
    // store guess card value

    public void GetGuessCardValue()
    {
        if (card != null)
        {
            card.GetCardValue();
            guessCardValue = card.cardValue;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Card"))
        {
            card = other.gameObject.GetComponent<Card>();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }
}
using UnityEngine;

/// <summary>
/// Handles card selection logic
/// Functions : Card movement into slots and removal of cards
/// </summary>

public class CardManager : MonoBehaviour
{
    public GameObject cardObject;  // active card selected
    private Stage cardSlots;

    public RectTransform cardSlot1;
    public RectTransform cardSlot2;

    void Awake()
    {
        cardSlots = FindFirstObjectByType<Stage>();
    }

    public void HandleCardSelected(Card selectedCard)  
    {
        cardSlots.cardOccupiedIncrement++;  // everytime a card is selected, increase by 1

        foreach (Transform slot in cardSlots.transform)  // loop through the card slots
        {
            if (slot.name == "CardSlot1" && slot.GetComponent<CardSlot>().isOccupied == false)
            {
                GameObject cardInstance = Instantiate(cardObject, slot);  // spawn new ghost card in slot
                cardInstance.transform.localPosition = Vector3.zero;   // ensure its centered properly
                slot.GetComponent<CardSlot>().isOccupied = true;
                cardInstance.GetComponent<Card>().isDuplicate = true;
                break;
            }
            else if (slot.name == "CardSlot2" && slot.GetComponent<CardSlot>().isOccupied == false)
            {
                GameObject cardInstance = Instantiate(cardObject, slot);
                cardInstance.transform.localPosition = Vector3.zero;
                slot.GetComponent<CardSlot>().isOccupied = true;
                cardInstance.GetComponent<Card>().isDuplicate = true;
                break;
            }
        }
    }

    public void ResetCardSlots()   // to clear the slots on new game
    {
        foreach (Transform slot in cardSlots.transform)
        {
            if (slot.GetComponent<CardSlot>().isOccupied == true)
            {
                foreach (Transform card in slot)
                {
                    Destroy(card.gameObject);
                }
                slot.GetComponent<CardSlot>().isOccupied = false;
            }
        }
    }
}
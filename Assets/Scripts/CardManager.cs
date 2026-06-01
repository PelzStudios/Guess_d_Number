using UnityEngine;
using DG.Tweening;

/// <summary>
/// Handles card selection logic
/// Functions : Card movement into slots and removal of cards
/// </summary>

public class CardManager : MonoBehaviour
{
    public GameObject cardObject;  // active card selected
    public Transform cardSlot1;
    public Transform cardSlot2;
    private Stage cardSlots;
   
    
    [HideInInspector]
    public GameObject cardInstance;

    void Awake()
    {
        cardSlots = FindFirstObjectByType<Stage>();
    }

/// <summary>
/// Handles the logic when a card is selected
/// - loops through each card slot and performs the duplicate card logic
/// </summary>
    public void HandleCardSelected()  
    {
        foreach (Transform slot in cardSlots.transform)  // loop through the card slots transforms
        {
            CardSlot slotComponent = slot.GetComponent<CardSlot>();

            if (slotComponent == null) continue;

            if ((slot.name == "CardSlot1" || slot.name == "CardSlot2") && !slotComponent.isOccupied)
            { 
                cardInstance = Instantiate(cardObject, cardObject.GetComponent<Card>().originalPosition);  

                MoveToPosition(slot.position);

                cardInstance.transform.SetParent(slot);
                cardInstance.transform.localPosition = Vector3.zero;   // ensure its centered properly

                slot.GetComponent<CardSlot>().isOccupied = true;
                GameEvents.OnCardEntered?.Invoke();

                cardInstance.GetComponent<Card>().isDuplicate = true;
                break;
            }
        }
    }
    
/// <summary>
/// Duplicate card animation logic
/// </summary>
    public void MoveToPosition(Vector3 targetPosition)
    {
        cardInstance.transform.DOMove(targetPosition, 0.3f);
    }

/// <summary>
/// Clears card slots for new session
/// </summary>
    public void ResetCardSlots()   // to clear the slots on new game
    {
        foreach (Transform slot in cardSlots.transform)  // loop through children
        {
            CardSlot slotComponent = slot.GetComponent<CardSlot>();

            if (slotComponent.isOccupied == true)
            {
                foreach (Transform card in slot)  // loop through children
                {
                    Destroy(card.gameObject);
                }

                slotComponent.isOccupied = false;
            }
        }
    }
}